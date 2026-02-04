using FootballCareerCompanion.Application.AI.Builders;
using FootballCareerCompanion.Application.AI.Generators;
using FootballCareerCompanion.Application.AI.PromptBuilders;
using FootballCareerCompanion.Application.Interfaces.Repositories;
using FootballCareerCompanion.Application.AI.Inputs.Enums;
using FootballCareerCompanion.Domain.Narratives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Application.Narrative
{
    public class SeasonNarrativeOrchestrator
    {
        private readonly SeasonNarrativeInputBuilder _inputBuilder;
        private readonly SeasonReportPromptBuilder _promptBuilder;
        private readonly ISeasonNarrativeGenerator _generator;
        private readonly INarrativeSnapshotRepository _snapshotRepository;

        public SeasonNarrativeOrchestrator(
            SeasonNarrativeInputBuilder inputBuilder,
            SeasonReportPromptBuilder promptBuilder,
            ISeasonNarrativeGenerator generator,
            INarrativeSnapshotRepository snapshotRepository)
        {
            _inputBuilder = inputBuilder;
            _promptBuilder = promptBuilder;
            _generator = generator;
            _snapshotRepository = snapshotRepository;
        }

        public async Task GenerateForSeasonAsync(
            Guid seasonId,
            int topScorerCount = 3,
            int forMatchCount = 10)
        {
            var input = await _inputBuilder.build(
                seasonId,
                topScorerCount,
                forMatchCount);

            var prompt = _promptBuilder.Build(input);

            var content = await _generator.GenerateAsync(prompt);

            var snapshot = NarrativeSnapshot.ForSeason(
                seasonId,
                content,
                promptVersion: "v1",
                modelVersion: "fake-ai");

            await _snapshotRepository.AddAsync(snapshot);
        }
    }
}
