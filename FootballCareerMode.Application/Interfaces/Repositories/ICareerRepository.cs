using FootballCareerMode.Domain.Careers;
using FootballCareerMode.Domain.Seasons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Application.Interfaces.Repositories
{
    public interface ICareerRepository
    {
        Task CreateCareerAsync(Career career);

        Task<Career?> GetCareerById(Guid careerId);
    }
}
