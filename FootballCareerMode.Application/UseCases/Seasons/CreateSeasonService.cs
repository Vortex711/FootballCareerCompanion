using FootballCareerMode.Application.Interfaces.Repositories;
using FootballCareerMode.Domain.Seasons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Application.UseCases.Seasons
{
    public class CreateSeasonService
    {
        private readonly ISeasonRepository _seasonRepository;
        private readonly ICareerRepository _careerRepository;

        public CreateSeasonService(ISeasonRepository seasonRepository, ICareerRepository careerRepository)
        {
            _seasonRepository = seasonRepository;
            _careerRepository = careerRepository;

        }

        public async Task<Guid> CreateSeason(
            Guid careerId,
            string name,
            DateTime? startDate,
            BoardExpectation expectation)
        {
            var career = await _careerRepository.GetCareerById(careerId);

            if (career == null)
                throw new InvalidOperationException("Career not found.");

            var season = new Season(
                id: Guid.NewGuid(),
                careerId: careerId,
                name: name,
                startDate: startDate,
                createdAt: DateTime.UtcNow,
                expectation: expectation);

            await _seasonRepository.CreateSeasonAsync(season);

            career.AddSeason(season);

            return season.Id;
        }
    }
}
