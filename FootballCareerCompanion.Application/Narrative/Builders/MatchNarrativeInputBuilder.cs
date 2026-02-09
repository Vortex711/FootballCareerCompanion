using FootballCareerCompanion.Application.AI.Inputs;
using FootballCareerCompanion.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Application.AI.Builders
{
    public class MatchNarrativeInputBuilder
    {
        private readonly ISeasonRepository _seasonRepository;

        public MatchNarrativeInputBuilder(ISeasonRepository seasonRepository)
        {
            _seasonRepository = seasonRepository;
        }

        public async Task<MatchNarrativeInput> BuildAsync(Guid matchId)
        {
            var match = await _seasonRepository.GetMatchWithSeasonAsync(matchId)
                ?? throw new InvalidOperationException("Match not found.");

            var goalEvents = match.Events.Select(e => new GoalEvent
            {
                Scorer = e.PlayerName,
                Minute = e.Minute
            }).ToList();

            var recentMatches = await _seasonRepository.GetRecentMatchesAsync(
                match.SeasonId,
                match.PlayedAt,
                5);

            var recentForm = string.Join("-",
                recentMatches.Select(m =>
                    m.TeamGoals > m.OpponentGoals ? "W" :
                    m.TeamGoals < m.OpponentGoals ? "L" : "D")
                );

            var headToHeadMatches = await _seasonRepository.GetHeadToHeadMatchesAsync(
                match.Season.CareerId,
                match.OpponentName,
                match.PlayedAt,
                3);

            var recentH2H = headToHeadMatches
                .Select(m => new HeadToHeadResult
                {
                    PlayedAt = m.PlayedAt,
                    CompetitionName = m.CompetitionName,
                    TeamGoals = m.TeamGoals,
                    OpponentGoals = m.OpponentGoals
                }).ToList();

            return new MatchNarrativeInput
            {
                CompetitionName = match.CompetitionName,
                TeamManagerName = match.Season.Career.ManagerName,
                TeamName = match.Season.Career.ClubName,
                OpponentName = match.OpponentName,
                IsHome = match.IsHome,

                TeamGoals = match.TeamGoals,
                OpponentGoals = match.OpponentGoals,

                LeaguePositionAfter = match.LeaguePositionAfter,
                LeaguePositionBefore = match.LeaguePositionBefore,

                Expectation = match.Season.Expectation,

                PlayedAt = match.PlayedAt,

                GoalEvents = goalEvents,

                RecentHeadToHeadResults = recentH2H,
                RecentForm = recentForm
            };
        }
    }
}
