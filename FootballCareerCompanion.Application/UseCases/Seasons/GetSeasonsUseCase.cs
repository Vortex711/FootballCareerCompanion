using FootballCareerCompanion.Application.Interfaces.Repositories;
using FootballCareerCompanion.Domain.Seasons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Application.UseCases.Seasons
{
    public class GetSeasonsUseCase
    {
        private readonly ISeasonRepository _seasonRepository;

        public GetSeasonsUseCase(ISeasonRepository seasonRepository)
        {
            _seasonRepository = seasonRepository;
        }

        public async Task<IReadOnlyList<Season>> GetSeasonsByCareerId(Guid careerId)
        {
            return await _seasonRepository.GetSeasonsByCareerId(careerId);
        }
    }
}
