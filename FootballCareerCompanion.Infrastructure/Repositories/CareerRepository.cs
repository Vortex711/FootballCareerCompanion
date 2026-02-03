using FootballCareerCompanion.Infrastructure.Persistence;
using FootballCareerCompanion.Application.Interfaces.Repositories;
using FootballCareerCompanion.Domain.Careers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Infrastructure.Repositories
{
    public class CareerRepository : ICareerRepository
    {
        private readonly FootballCareerCompanionDbContext _db;
        public CareerRepository(FootballCareerCompanionDbContext db)
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
