using FootballCareerCompanion.Application.Interfaces.Repositories;
using FootballCareerCompanion.Application.AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Application.UseCases.Matches
{
    public class GetMatchNarrativeService
    {
        private readonly INarrativeSnapshotRepository _repository;

        public GetMatchNarrativeService(INarrativeSnapshotRepository repository)
        {
            _repository = repository;
        }

        public async Task<string?> GetNarrativeAsync(Guid matchId)
        {
            var snapshot = await _repository.GetByMatchIdAsync(matchId);
            return snapshot?.Content;
        }
    }
}
