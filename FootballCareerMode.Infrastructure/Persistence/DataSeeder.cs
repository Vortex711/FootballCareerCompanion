using FootballCareerMode.Domain.Careers;
using FootballCareerMode.Domain.Seasons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Infrastructure.Persistence
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(FootballCareerModeDbContext db)
        {
            // If we already have a career, assume DB is seeded
            if (await db.Careers.AnyAsync())
                return;

            //var careerId = Guid.NewGuid();
            //var seasonId = Guid.NewGuid();

            //var career = new Career(
            //    careerId,
            //    "My Career",
            //    "Real Madrid",
            //    DateTime.UtcNow
            //);

            //var season = new Season(
            //    seasonId,
            //    careerId,
            //    "2024–25",
            //    DateTime.UtcNow,
            //    DateTime.UtcNow
            //);

            //db.Careers.Add(career);
            //db.Seasons.Add(season);

            await db.SaveChangesAsync();
        }
    }
}
