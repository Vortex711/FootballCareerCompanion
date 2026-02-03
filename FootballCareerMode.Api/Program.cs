using FootballCareerMode.Application.AI;
using FootballCareerMode.Application.AI.Builders;
using FootballCareerMode.Application.AI.Generators;
using FootballCareerMode.Application.AI.PromptBuilders;
using FootballCareerMode.Application.Interfaces.Repositories;
using FootballCareerMode.Application.UseCases.Careers;
using FootballCareerMode.Application.UseCases.Matches;
using FootballCareerMode.Application.UseCases.Seasons;
using FootballCareerMode.Infrastructure;
using FootballCareerMode.Infrastructure.Persistence;
using FootballCareerMode.Infrastructure.Repositories;
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

//   Snapshot Repository
builder.Services.AddScoped<INarrativeSnapshotRepository, NarrativeSnapshotRepository>();

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
    var db = scope.ServiceProvider.GetRequiredService<FootballCareerModeDbContext>();
    await DataSeeder.SeedAsync(db);
}

app.Run();
