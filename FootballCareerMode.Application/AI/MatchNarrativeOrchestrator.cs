using FootballCareerMode.Application.AI.Builders;
using FootballCareerMode.Application.AI.Generators;
using FootballCareerMode.Application.AI.PromptBuilders;
using FootballCareerMode.Application.Interfaces.Repositories;
using FootballCareerMode.Domain.Narratives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Application.AI
{
    public class MatchNarrativeOrchestrator
    {
        private readonly MatchNarrativeInputBuilder _inputBuilder;
        private readonly MatchReportPromptBuilder _promptBuilder;
        private readonly IMatchNarrativeGenerator _generator;
        private readonly INarrativeSnapshotRepository _snapshotRepository;

        public MatchNarrativeOrchestrator(
        MatchNarrativeInputBuilder inputBuilder,
        MatchReportPromptBuilder promptBuilder,
        IMatchNarrativeGenerator generator,
        INarrativeSnapshotRepository snapshotRepository)
        {
            _inputBuilder = inputBuilder;
            _promptBuilder = promptBuilder;
            _generator = generator;
            _snapshotRepository = snapshotRepository;
        }

        public async Task GenerateForMatchAsync(Guid matchId)
        {
            var input = await _inputBuilder.BuildAsync(matchId);

            var prompt = _promptBuilder.Build(input);

            var content = await _generator.GenerateAsync(input);

            var snapshot = NarrativeSnapshot.ForMatch(
                matchId,
                content,
                promptVersion: "v1",
                modelVersion: "fake-ai"
            );

            await _snapshotRepository.AddAsync(snapshot);
        }
    }
}
