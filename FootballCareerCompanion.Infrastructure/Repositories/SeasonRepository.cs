using FootballCareerCompanion.Infrastructure.Persistence;
using FootballCareerCompanion.Application.Interfaces.Repositories;
using FootballCareerCompanion.Domain.Matches;
using FootballCareerCompanion.Domain.Seasons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Infrastructure.Repositories
{
    public class SeasonRepository : ISeasonRepository
    {
        private readonly FootballCareerCompanionDbContext _db;

        public SeasonRepository(FootballCareerCompanionDbContext db)
        {
            _db = db;
        }

        public async Task CreateSeasonAsync(Season season)
        {
            _db.Seasons.Add(season);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync()
        {
            await _db.SaveChangesAsync();
        }


        public async Task<Season?> GetByIdAsync(Guid seasonId)
        {
            return await _db.Seasons
                .Include(s => s.Career)
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

        public async Task<Match?> GetMatchWithSeasonAsync(Guid matchId)
        {
            return await _db.Matches
                .Include(m => m.Events)
                .Include(m => m.Season)
                .ThenInclude(s => s.Career)
                .FirstOrDefaultAsync(m => m.Id == matchId);
        }

        public async Task<IReadOnlyList<Match>> GetRecentMatchesAsync(
            Guid seasonId,
            DateTime before,
            int count)
        {
            return await _db.Matches
                .Where(m => m.SeasonId == seasonId && m.PlayedAt < before)
                .OrderByDescending(m => m.PlayedAt)
                .Take(count)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Match>> GetHeadToHeadMatchesAsync(
            Guid careerId,
            string opponentName,
            DateTime before,
            int limit
        )
        {
            return await _db.Matches
                .Include(m => m.Season)
                .Where(m =>
                    m.Season.CareerId == careerId &&
                    m.OpponentName == opponentName &&
                    m.PlayedAt < before)
                .OrderByDescending(m => m.PlayedAt)
                .Take(limit)
                .ToListAsync();
        }
    }
}
