using FootballCareerCompanion.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Application.UseCases.Seasons
{
    public class EndSeasonUseCase
    {
        private readonly ISeasonRepository _seasonRepository;

        public EndSeasonUseCase(ISeasonRepository seasonRepository)
        {
            _seasonRepository = seasonRepository;
        }

        public async Task EndSeasonAsync(
            Guid seasonId, 
            DateTime? endDate)
        {
            var season = await _seasonRepository.GetByIdAsync(seasonId) ??
                throw new InvalidOperationException("Season does not exist.");

            if (endDate == null)
            {
                if (!season.Matches.Any())
                    throw new InvalidOperationException("Cannot end season without matches or explicit end date");
                endDate = season.Matches.Max(m => m.PlayedAt);
            }
                
                

            season.EndSeason(endDate.Value);
            await _seasonRepository.UpdateAsync();
        }
    }
}
