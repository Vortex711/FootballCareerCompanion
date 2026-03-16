using FootballCareerCompanion.Application.AI.Builders;
using FootballCareerCompanion.Application.AI.Generators;
using FootballCareerCompanion.Application.AI.PromptBuilders;
using FootballCareerCompanion.Application.Interfaces.Repositories;
using FootballCareerCompanion.Application.Interfaces.Security;
using FootballCareerCompanion.Application.Narrative;
using FootballCareerCompanion.Application.UseCases.Careers;
using FootballCareerCompanion.Application.UseCases.Matches;
using FootballCareerCompanion.Application.UseCases.Seasons;
using FootballCareerCompanion.Infrastructure;
using FootballCareerCompanion.Infrastructure.Persistence;
using FootballCareerCompanion.Infrastructure.Repositories;
using FootballCareerCompanion.Infrastructure.Security;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;
using FootballCareerCompanion.Infrastructure.AI.Gemini;
using FootballCareerCompanion.Application.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!);

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

builder.Services.AddAuthorization();

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Application services
//   Submit Match
builder.Services.AddScoped<SubmitMatchUseCase>();
//   Create Career
builder.Services.AddScoped<CreateCareerUseCase>();
//   Get Careers
builder.Services.AddScoped<GetCareersUseCase>();
//   Create Season
builder.Services.AddScoped<CreateSeasonUseCase>();
//   End Season
builder.Services.AddScoped<EndSeasonUseCase>();
//   Get Seasons
builder.Services.AddScoped<GetSeasonsUseCase>();

//Jwt Services
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

//   Match Narrative
builder.Services.AddScoped<MatchNarrativeInputBuilder>();
builder.Services.AddScoped<MatchReportPromptBuilder>();
builder.Services.AddScoped<IMatchNarrativeGenerator, FakeMatchNarrativeGenerator>();
builder.Services.AddScoped<MatchNarrativeOrchestrator>();
builder.Services.AddScoped<GetMatchNarrativeUseCase>();
builder.Services.Configure<GeminiOptions>(
    builder.Configuration.GetSection(GeminiOptions.SectionName));
builder.Services.AddHttpClient<ILLMService, GeminiLLMService>();

//   SeasonNarrative
builder.Services.AddScoped<SeasonNarrativeInputBuilder>();
builder.Services.AddScoped<SeasonReportPromptBuilder>();
builder.Services.AddScoped<ISeasonNarrativeGenerator, FakeSeasonNarrativeGenerator>();
builder.Services.AddScoped<SeasonNarrativeOrchestrator>();
builder.Services.AddScoped<SeasonNarrativeUseCase>();

//   Infrastructure
builder.Services.AddInfrastructure(
    builder.Configuration.GetConnectionString("DefaultConnection")!
);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter()));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<FootballCareerCompanionDbContext>();
}

app.Run();
