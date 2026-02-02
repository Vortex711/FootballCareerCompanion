using FootballCareerMode.Application.AI;
using FootballCareerMode.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Application.UseCases.Seasons
{
    public class SeasonNarrativeService
    {
        private readonly INarrativeSnapshotRepository _repository;
        private readonly SeasonNarrativeOrchestrator _orchestrator;

        public SeasonNarrativeService(
            INarrativeSnapshotRepository repository,
            SeasonNarrativeOrchestrator orchestrator)
        {
            _repository = repository;
            _orchestrator = orchestrator;
        }

        public async Task GenerateNarrativeAsync(Guid seasonId)
        {
            await _orchestrator.GenerateForSeasonAsync(seasonId);
        }

        public async Task<string?> GetNarrativeAsync(Guid seasonId)
        {
            var snapshot = await _repository.GetBySeasonIdAsync(seasonId);
            return snapshot?.Content;
        }
    }
}
