using FootballCareerMode.Domain.Matches;
using FootballCareerMode.Domain.Seasons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Application.Interfaces.Repositories
{
    public interface ISeasonRepository
    {
        Task<Season?> GetByIdAsync(Guid seasonId);
        Task AddMatchAsync(Match matches);
        Task<bool> MatchExistsAsync(
            Guid seasonId,
            string competitionName,
            string opponentName,
            DateTime playedAt);
        Task<Match?> GetMatchWithSeasonAsync(Guid matchId);
        Task<IReadOnlyList<Match>> GetRecentMatchesAsync(
            Guid seasonId,
            DateTime before,
            int count);

        Task<IReadOnlyList<Match>> GetHeadToHeadMatchesAsync(
            Guid careerId,
            string opponentName,
            DateTime before,
            int limit
        );

    }
}
