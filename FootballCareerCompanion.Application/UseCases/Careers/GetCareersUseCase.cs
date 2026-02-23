using FootballCareerCompanion.Application.Interfaces.Repositories;
using FootballCareerCompanion.Domain.Careers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Application.UseCases.Careers
{
    public class GetCareersUseCase
    {
        private readonly ICareerRepository _careerRepository;

        public GetCareersUseCase(ICareerRepository careerRepository)
        {
            _careerRepository = careerRepository;
        }

        public async Task<IReadOnlyList<Career>> GetCareersByUserId(Guid userId)
        {
            return await _careerRepository.GetCareersByUserId(userId);
        }
    }
}
