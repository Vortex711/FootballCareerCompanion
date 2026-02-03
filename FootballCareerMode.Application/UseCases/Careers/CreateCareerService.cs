using FootballCareerMode.Application.Interfaces.Repositories;
using FootballCareerMode.Domain.Careers;
using FootballCareerMode.Domain.Seasons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Application.UseCases.Careers
{
    public class CreateCareerService
    {
        private readonly ICareerRepository _careerRepository;

        public CreateCareerService(ICareerRepository careerRepository)
        {
            _careerRepository = careerRepository;
        }

        public async Task<Guid> CreateCareerAsync(
            string name,
            string clubName,
            string managerName)
        {
            var career = new Career(
                id: Guid.NewGuid(),
                name: name,
                clubName: clubName,
                managerName: managerName,
                createdAt: DateTime.UtcNow);

            await _careerRepository.CreateCareerAsync(career);
            return career.Id;
        }
    }
}
