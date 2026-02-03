using FootballCareerMode.Domain.Careers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Application.Interfaces.Repositories
{
    public interface ICareerRepository
    {
        Task AddCareerAsync(Career career);

        Task<Career?> GetCareerById(Guid careerId);
    }
}
