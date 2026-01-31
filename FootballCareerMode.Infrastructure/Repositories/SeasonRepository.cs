using FootballCareerMode.Application.Interfaces.Repositories;
using FootballCareerMode.Domain.Matches;
using FootballCareerMode.Domain.Seasons;
using FootballCareerMode.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Infrastructure.Repositories
{
    public class SeasonRepository : ISeasonRepository
    {
        private readonly FootballCareerModeDbContext _db;

        public SeasonRepository(FootballCareerModeDbContext db)
        {
            _db = db;
        }

        public async Task<Season?> GetByIdAsync(Guid seasonId)
        {
            return await _db.Seasons
                .Include(s => s.Matches)
                .ThenInclude(m => m.Events)
                .FirstOrDefaultAsync(s => s.Id == seasonId);
        }

        public async Task AddMatchAsync(Match match)
        {
            _db.Matches.Add(match);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> MatchExistsAsync(
            Guid seasonId,
            string competitionName,
            string opponentName,
            DateTime playedAt)
        {
            return await _db.Matches.AnyAsync(m =>
                m.SeasonId == seasonId &&
                m.CompetitionName == competitionName &&
                m.OpponentName == opponentName &&
                m.PlayedAt == playedAt.ToUniversalTime());
        }
    }
}
