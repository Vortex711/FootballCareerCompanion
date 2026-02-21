using FootballCareerCompanion.Application.Interfaces.Repositories;
using FootballCareerCompanion.Domain.Careers;
using FootballCareerCompanion.Domain.Seasons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Application.UseCases.Careers
{
    public class CreateCareerUseCase
    {
        private readonly ICareerRepository _careerRepository;

        public CreateCareerUseCase(ICareerRepository careerRepository)
        {
            _careerRepository = careerRepository;
        }

        public async Task<Guid> CreateCareerAsync(
            Guid userId,
            string name,
            string clubName,
            string managerName)
        {
            var career = new Career(
                id: Guid.NewGuid(),
                userId: userId,
                name: name,
                clubName: clubName,
                managerName: managerName,
                createdAt: DateTime.UtcNow);

            await _careerRepository.CreateCareerAsync(career);
            return career.Id;
        }
    }
}
