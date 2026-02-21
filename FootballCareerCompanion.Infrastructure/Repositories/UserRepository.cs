using FootballCareerCompanion.Application.Interfaces.Repositories;
using FootballCareerCompanion.Domain.Users;
using FootballCareerCompanion.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FootballCareerCompanionDbContext _db;

        public UserRepository(FootballCareerCompanionDbContext db)
        {
            _db = db;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user; 
        }

        public async Task AddAsync(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync(); 
        }
    }
}
