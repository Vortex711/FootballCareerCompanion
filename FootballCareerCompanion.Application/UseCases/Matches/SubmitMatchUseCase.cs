using FootballCareerCompanion.Application.DTOs.Matches;
using FootballCareerCompanion.Application.Interfaces.Repositories;
using FootballCareerCompanion.Application.Narrative;
using FootballCareerCompanion.Domain.Matches;
using FootballCareerCompanion.Domain.MatchEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Application.UseCases.Matches
{
    public class SubmitMatchUseCase
    {
        private readonly ISeasonRepository _seasonRepository;
        private readonly MatchNarrativeOrchestrator _narrativeOrchestrator;

        public SubmitMatchUseCase(ISeasonRepository seasonRepository, MatchNarrativeOrchestrator narrativeOrchestrator)
        {
            _seasonRepository = seasonRepository;
            _narrativeOrchestrator = narrativeOrchestrator;
        }

        public async Task<Guid> SubmitAsync(
            Guid seasonId,
            string competitionName,
            string opponentName,
            bool isHome,
            int teamGoals,
            int opponentGoals,
            int? leaguePositionAfter,
            DateTime playedAt,
            List<GoalEventRequest>? goalEvents)
        {
            var normalizedPlayedAt = DateTime.SpecifyKind(
                playedAt,
                DateTimeKind.Utc
            );
            //1.Load Season
            var season = await _seasonRepository.GetByIdAsync(seasonId);
            if (season == null)
                throw new InvalidOperationException("Season not found.");

            //2.Duplication check (Idempotency)
            var exists = await _seasonRepository.MatchExistsAsync(
                seasonId,
                competitionName,
                opponentName,
                normalizedPlayedAt);

            if (exists)
                throw new InvalidOperationException("Duplicate match submission.");

            int? leaguePositionBefore = season.LeaguePosition;

            //3.Create Match
            var match = new Match(
                id: Guid.NewGuid(),
                seasonId: seasonId,
                competitionName: competitionName,
                opponentName: opponentName,
                isHome: isHome,
                teamGoals: teamGoals,
                opponentGoals: opponentGoals,
                leaguePositionBefore: leaguePositionBefore,
                leaguePositionAfter: leaguePositionAfter,
                playedAt: normalizedPlayedAt,
                createdAt: DateTime.UtcNow);

            //4.Add Goal Events (optional)
            if (goalEvents != null)
            {
                foreach(var goal in goalEvents)
                {
                    var matchEvent = new MatchEvent(
                        id: Guid.NewGuid(),
                        matchId: match.Id,
                        playerName: goal.PlayerName,
                        minute: goal.Minute);

                    match.AddGoalEvent(matchEvent);
                }
            }

            //5.Add season start date if current match is the first
            if (season.Matches.Count == 0 && season.StartDate == null)
                season.StartSeason(playedAt);

            //6.Attach match and update league position in season
            season.AddMatch(match);
            season.UpdateLeaguePosition(leaguePositionAfter);

            await _seasonRepository.AddMatchAsync(match);

            await _narrativeOrchestrator.GenerateForMatchAsync(match.Id);

            await _narrativeOrchestrator.GenerateForMatchAsync(match.Id);


            return match.Id;
        }
    }
}
