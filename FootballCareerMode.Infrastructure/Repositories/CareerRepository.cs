using FootballCareerMode.Application.Interfaces.Repositories;
using FootballCareerMode.Domain.Careers;
using FootballCareerMode.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Infrastructure.Repositories
{
    public class CareerRepository : ICareerRepository
    {
        private readonly FootballCareerModeDbContext _db;
        public CareerRepository(FootballCareerModeDbContext db)
        {
            _db = db;
        }

        public async Task CreateCareerAsync(Career career)
        {
            _db.Careers.Add(career);
            await _db.SaveChangesAsync();
        }

        public async Task<Career?> GetCareerById(Guid careerId)
        {
            var career = await _db.Careers.FirstOrDefaultAsync(c => c.Id == careerId);
            return career;
        }
    }
}
