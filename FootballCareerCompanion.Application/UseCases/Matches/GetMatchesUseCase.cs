using FootballCareerCompanion.Application.Interfaces.Repositories;
using FootballCareerCompanion.Domain.Matches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Application.UseCases.Matches
{
    public class GetMatchesUseCase
    {
        private readonly ISeasonRepository _repository;

        public GetMatchesUseCase(ISeasonRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<Match>> GetMatchesBySeasonId(Guid seasonId)
        {
            return await _repository.GetMatchesBySeasonIdAsync(seasonId);
        }
    }
}
