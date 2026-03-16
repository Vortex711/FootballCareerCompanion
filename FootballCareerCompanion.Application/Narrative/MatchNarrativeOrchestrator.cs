using FootballCareerCompanion.Application.AI.Builders;
using FootballCareerCompanion.Application.AI.Generators;
using FootballCareerCompanion.Application.AI.PromptBuilders;
using FootballCareerCompanion.Application.Interfaces;
using FootballCareerCompanion.Application.Interfaces.Repositories;
using FootballCareerCompanion.Domain.Narratives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Application.Narrative
{
    public class MatchNarrativeOrchestrator
    {
        private readonly MatchNarrativeInputBuilder _inputBuilder;
        private readonly MatchReportPromptBuilder _promptBuilder;
        private readonly ILLMService _llmService;
        private readonly INarrativeSnapshotRepository _snapshotRepository;

        public MatchNarrativeOrchestrator(
        MatchNarrativeInputBuilder inputBuilder,
        MatchReportPromptBuilder promptBuilder,
        ILLMService llmService,
        INarrativeSnapshotRepository snapshotRepository)
        {
            _inputBuilder = inputBuilder;
            _promptBuilder = promptBuilder;
            _llmService = llmService;
            _snapshotRepository = snapshotRepository;
        }

        public async Task GenerateForMatchAsync(Guid matchId)
        {
            var input = await _inputBuilder.BuildAsync(matchId);

            var prompt = _promptBuilder.Build(input);

            string content;

            try
            {
                content = await _llmService.GenerateAsync(prompt);
            }
            catch
            {
                content = "Narrative generation unavailable for this match.";
            }
            

            var snapshot = NarrativeSnapshot.ForMatch(
                matchId,
                content,
                promptVersion: "v1",
                modelVersion: "gemini-flash"
            );

            await _snapshotRepository.AddAsync(snapshot);
        }
    }
}
