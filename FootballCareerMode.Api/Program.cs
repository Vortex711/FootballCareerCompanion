using FootballCareerMode.Application.AI;
using FootballCareerMode.Application.AI.Generators;
using FootballCareerMode.Application.AI.Inputs;
using FootballCareerMode.Application.AI.PromptBuilders;
using FootballCareerMode.Application.Interfaces.Repositories;
using FootballCareerMode.Application.UseCases.Matches;
using FootballCareerMode.Infrastructure;
using FootballCareerMode.Infrastructure.Persistence;
using FootballCareerMode.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Application services
builder.Services.AddScoped<SubmitMatchService>();
builder.Services.AddScoped<MatchNarrativeInputBuilder>();
builder.Services.AddScoped<MatchReportPromptBuilder>();
builder.Services.AddScoped<IMatchNarrativeGenerator, FakeMatchNarrativeGenerator>();
builder.Services.AddScoped<MatchNarrativeOrchestrator>();
builder.Services.AddScoped<INarrativeSnapshotRepository, NarrativeSnapshotRepository>();
builder.Services.AddScoped<GetMatchNarrativeService>();



// Infrastructure
builder.Services.AddInfrastructure(
    builder.Configuration.GetConnectionString("DefaultConnection")!
);

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
