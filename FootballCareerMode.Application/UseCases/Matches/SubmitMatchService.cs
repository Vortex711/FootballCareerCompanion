using FootballCareerMode.Application.DTOs.Matches;
using FootballCareerMode.Application.Interfaces.Repositories;
using FootballCareerMode.Domain.Matches;
using FootballCareerMode.Domain.MatchEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Application.UseCases.Matches
{
    public class SubmitMatchService
    {
        private readonly ISeasonRepository _seasonRepository;

        public SubmitMatchService(ISeasonRepository seasonRepository)
        {
            _seasonRepository = seasonRepository;
        }

        public async Task<Guid> SubmitAsync(SubmitMatchRequest request)
        {
            //1.Load Season
            var season = await _seasonRepository.GetByIdAsync(request.SeasonId);
            if (season == null)
                throw new InvalidOperationException("Season not found.");

            //2.Duplication check (Idempotency)
            var exists = await _seasonRepository.MatchExistsAsync(
                request.SeasonId,
                request.CompetitionName,
                request.OpponentName,
                request.PlayedAt);

            if (exists)
                throw new InvalidOperationException("Duplicate match submission.");

            //3.Create Match
            var match = new Match(
                id: Guid.NewGuid(),
                seasonId: request.SeasonId,
                competitionName: request.CompetitionName,
                opponentName: request.OpponentName,
                isHome: request.IsHome,
                teamGoals: request.TeamGoals,
                opponentGoals: request.OpponentGoals,
                playedAt: request.PlayedAt,
                createdAt: DateTime.UtcNow);

            //4.Add Goal Events (optional)
            if (request.GoalEvents != null)
            {
                foreach(var goal in request.GoalEvents)
                {
                    var matchEvent = new MatchEvent(
                        id: Guid.NewGuid(),
                        matchId: match.Id,
                        playerName: goal.PlayerName,
                        minute: goal.Minute);

                    match.AddGoalEvent(matchEvent);
                }
            }

            //5.Attach match to season
            season.AddMatch(match);

            await _seasonRepository.AddMatchAsync(match);

            return match.Id;
        }
    }
}
