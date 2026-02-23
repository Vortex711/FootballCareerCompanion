using FootballCareerCompanion.Domain.Careers;
using FootballCareerCompanion.Domain.Seasons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Application.Interfaces.Repositories
{
    public interface ICareerRepository
    {
        Task CreateCareerAsync(Career career);

        Task<Career?> GetCareerById(Guid careerId);

        Task<IReadOnlyList<Career>> GetCareersByUserId(Guid userId);
    }
}
