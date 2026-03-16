using FootballCareerCompanion.Application.Interfaces.Repositories;
using FootballCareerCompanion.Application.Narrative;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Application.UseCases.Seasons
{
    public class SeasonNarrativeUseCase
    {
        private readonly INarrativeSnapshotRepository _repository;
        private readonly SeasonNarrativeOrchestrator _orchestrator;

        public SeasonNarrativeUseCase(
            INarrativeSnapshotRepository repository,
            SeasonNarrativeOrchestrator orchestrator)
        {
            _repository = repository;
            _orchestrator = orchestrator;
        }

        public async Task<string> GenerateNarrativeAsync(Guid seasonId)
        {
            await _orchestrator.GenerateForSeasonAsync(seasonId);

            var snapshot = await _repository.GetBySeasonIdAsync(seasonId)
                ?? throw new InvalidOperationException("Narrative snapshot was not generated.");

            return snapshot.Content;
        }
    }
}
