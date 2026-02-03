using FootballCareerCompanion.Application.AI;
using FootballCareerCompanion.Application.AI.Builders;
using FootballCareerCompanion.Application.AI.Generators;
using FootballCareerCompanion.Application.AI.PromptBuilders;
using FootballCareerCompanion.Application.Interfaces.Repositories;
using FootballCareerCompanion.Application.UseCases.Careers;
using FootballCareerCompanion.Application.UseCases.Matches;
using FootballCareerCompanion.Application.UseCases.Seasons;
using FootballCareerCompanion.Infrastructure;
using FootballCareerCompanion.Infrastructure.Persistence;
using FootballCareerCompanion.Infrastructure.Repositories;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Application services
//   Submit Match
builder.Services.AddScoped<SubmitMatchService>();
//   Create Career
builder.Services.AddScoped<CreateCareerService>();
//   Create Season
builder.Services.AddScoped<CreateSeasonService>();
//   End Season
builder.Services.AddScoped<EndSeasonService>();

//   Match Narrative
builder.Services.AddScoped<MatchNarrativeInputBuilder>();
builder.Services.AddScoped<MatchReportPromptBuilder>();
builder.Services.AddScoped<IMatchNarrativeGenerator, FakeMatchNarrativeGenerator>();
builder.Services.AddScoped<MatchNarrativeOrchestrator>();
builder.Services.AddScoped<GetMatchNarrativeService>();

//   SeasonNarrative
builder.Services.AddScoped<SeasonNarrativeInputBuilder>();
builder.Services.AddScoped<SeasonReportPromptBuilder>();
builder.Services.AddScoped<ISeasonNarrativeGenerator, FakeSeasonNarrativeGenerator>();
builder.Services.AddScoped<SeasonNarrativeOrchestrator>();
builder.Services.AddScoped<SeasonNarrativeService>();

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

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<FootballCareerCompanionDbContext>();
}

app.Run();
