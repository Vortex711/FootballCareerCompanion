using FootballCareerMode.Application.AI.Inputs;
using FootballCareerMode.Application.AI.Inputs.Enums;
using FootballCareerMode.Application.AI.Inputs.Helpers;
using FootballCareerMode.Application.Interfaces.Repositories;
using FootballCareerMode.Domain.Matches;
using FootballCareerMode.Domain.Seasons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Application.AI.Builders
{
    public class SeasonNarrativeInputBuilder
    {
        private readonly ISeasonRepository _seasonRepository;
        public SeasonNarrativeInputBuilder(ISeasonRepository seasonRepository)
        {
            _seasonRepository = seasonRepository;
        }

        public async Task<SeasonNarrativeInput> build(
            Guid seasonId,
            int topScorerCount,
            int formMatchCount)
        {
            var season = await _seasonRepository.GetByIdAsync(seasonId)
                ?? throw new InvalidOperationException("Season does not exist.");

            var invocationType = season.EndDate == null ?
                SeasonInvocationType.MidSeason :
                SeasonInvocationType.EndOfSeason;

            var matches = season.Matches.ToList();

            var matchesPlayed = matches.Count;

            int wins = 0, draws = 0, losses = 0, goalsFor = 0, goalsAgainst = 0;

            foreach (var match in matches)
            {
                goalsFor += match.TeamGoals;
                goalsAgainst += match.OpponentGoals;

                if (match.TeamGoals > match.OpponentGoals)
                    wins++;
                else if (match.TeamGoals == match.OpponentGoals)
                    draws++;
                else
                    losses++;
            }

            var recentMatches = matches
                .TakeLast(formMatchCount)
                .ToList();

            var recentForm = BuildFormSnapshot(recentMatches);

            var goalEvents = matches
                .SelectMany(m => m.Events)
                .Where(e => e.Minute.HasValue);

            int goalsEarly = 0, goalsMid = 0, goalsLate = 0;

            foreach (var goal in goalEvents)
            {
                if (goal.Minute > 0 && goal.Minute <= 30)
                    goalsEarly++;
                else if (goal.Minute <= 60)
                    goalsMid++;
                else
                    goalsLate++;
            }

            var topScorers = matches
                .SelectMany(m => m.Events)
                .GroupBy(e => e.PlayerName)
                .Select(g => new TopScorerSummary
                {
                    PlayerName = g.Key,
                    Goals = g.Count()
                })
                .OrderByDescending(s => s.Goals)
                .ThenBy(s => s.PlayerName)
                .Take(topScorerCount)
                .ToList();

            var homeRecord = new VenueRecord();
            var awayRecord = new VenueRecord();

            foreach (var match in matches)
            {
                var record = match.IsHome ? homeRecord : awayRecord;

                if (match.TeamGoals > match.OpponentGoals)
                    record.Wins++;
                else if (match.TeamGoals == match.OpponentGoals)
                    record.Draws++;
                else
                    record.Losses++;
            }

            NarrativeToneHint toneHint;

            if (wins > losses)
            {
                toneHint = NarrativeToneHint.Optimistic;
            }
            else if (losses > wins)
            {
                toneHint = NarrativeToneHint.Critical;
            }
            else
            {
                // wins == losses
                toneHint = matchesPlayed < 10
                    ? NarrativeToneHint.Measured      // season still forming
                    : NarrativeToneHint.Critical;     // balance feels disappointing
            }


            return new SeasonNarrativeInput
            {
                ClubName = season.Career.ClubName,
                SeasonName = season.Name,

                InvocationType = invocationType,
                MatchesPlayed = matches.Count,

                Wins = wins,
                Draws = draws,
                Losses = losses,
                GoalsFor = goalsFor,
                GoalsAgainst = goalsAgainst,
                GoalDifference = goalsFor - goalsAgainst,

                RecentFormMatchCount = formMatchCount,
                RecentForm = recentForm,
                GoalsScoredByPhase = new GoalPhaseDistribution
                {
                    EarlyGame = goalsEarly,
                    MidGame = goalsMid,
                    LateGame = goalsLate
                },
                TopScorers = topScorers,

                Home = homeRecord,
                Away = awayRecord,

                ToneHint = toneHint
            };
        }
        private static FormSnapshot BuildFormSnapshot(IEnumerable<Match> matches)
        {
            int wins = 0, draws = 0, losses = 0;
            int goalsFor = 0, goalsAgainst = 0;

            foreach (var match in matches)
            {
                goalsFor += match.TeamGoals;
                goalsAgainst += match.OpponentGoals;

                if (match.TeamGoals > match.OpponentGoals) wins++;
                else if (match.TeamGoals < match.OpponentGoals) losses++;
                else draws++;
            }

            return new FormSnapshot
            {
                Matches = matches.Count(),
                Wins = wins,
                Draws = draws,
                Losses = losses,
                GoalsFor = goalsFor,
                GoalsAgainst = goalsAgainst
            };
        }
    }
}
