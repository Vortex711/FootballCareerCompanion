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

        public async Task<Guid> SubmitAsync(SubmitMatchRequest request)
        {
            var normalizedPlayedAt = DateTime.SpecifyKind(
                request.PlayedAt,
                DateTimeKind.Utc
            );
            //1.Load Season
            var season = await _seasonRepository.GetByIdAsync(request.SeasonId);
            if (season == null)
                throw new InvalidOperationException("Season not found.");

            //2.Duplication check (Idempotency)
            var exists = await _seasonRepository.MatchExistsAsync(
                request.SeasonId,
                request.CompetitionName,
                request.OpponentName,
                normalizedPlayedAt);

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
                playedAt: normalizedPlayedAt,
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

            //_ = Task.Run(async () =>
            //{
            //    try
            //    {
            //        Console.WriteLine("AI background task started");
            //        await _narrativeOrchestrator.GenerateForMatchAsync(match.Id);
            //        Console.WriteLine("AI generation completed");
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.ToString());
            //    }
            //});

            await _narrativeOrchestrator.GenerateForMatchAsync(match.Id);


            return match.Id;
        }
    }
}
