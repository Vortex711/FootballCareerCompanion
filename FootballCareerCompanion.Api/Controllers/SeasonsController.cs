using FootballCareerCompanion.Application.DTOs.Matches;
using FootballCareerCompanion.Application.DTOs.Seasons;
using FootballCareerCompanion.Application.UseCases.Matches;
using FootballCareerCompanion.Application.UseCases.Seasons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace FootballCareerCompanion.Api.Controllers
{
    [Authorize]
    [Route("api/v1/seasons")]
    [ApiController]
    public class SeasonsController : ControllerBase
    {
        private readonly SeasonNarrativeUseCase _seasonNarrativeService;
        private readonly GetSeasonsUseCase _getSeasonsUseCase;
        private readonly EndSeasonUseCase _endSeasonService;
        private readonly GetMatchesUseCase _getMatchesUseCase;

        public SeasonsController(
            SeasonNarrativeUseCase seasonNarrativeService,
            GetSeasonsUseCase getSeasonsUseCase,
            EndSeasonUseCase endSeasonService,
            GetMatchesUseCase getMatchesUseCase)
        {
            _seasonNarrativeService = seasonNarrativeService;
            _getSeasonsUseCase = getSeasonsUseCase;
            _endSeasonService = endSeasonService;
            _getMatchesUseCase = getMatchesUseCase; 
        }

        [HttpGet("/api/v1/careers/{careerId:guid}/seasons")]
        public async Task<IActionResult> GetSeasonsByCareerId(Guid careerId)
        {
            var seasons = await _getSeasonsUseCase.GetSeasonsByCareerId(careerId);

            return Ok(seasons.Select(s => new SeasonResponse
            {
                Id = s.Id,
                Name = s.Name,
                BoardExpectation = s.Expectation.ToString(),
                LeaguePosition = s.LeaguePosition,
                StartDate = s.StartDate,
                EndDate = s.EndDate
            }));
        }

        [HttpPost("{seasonId:guid}/end")]
        public async Task<IActionResult> EndSeason(
            Guid seasonId,
            [FromBody] DateTime? endDate)
        {
            await _endSeasonService.EndSeasonAsync(
                seasonId,
                endDate);

            return NoContent();
        }

        [HttpPost("{seasonId:guid}/narrative")]
        public async Task<IActionResult> GenerateSeasonNarrative(Guid seasonId)
        {
            await _seasonNarrativeService.GenerateNarrativeAsync(seasonId);

            return Accepted();
        }

        [HttpGet("{seasonId:guid}/narrative")]
        public async Task<IActionResult> GetSeasonNarrative(Guid seasonId)
        {
            var narrative = await _seasonNarrativeService.GetNarrativeAsync(seasonId);

            if (narrative == null)
                return NotFound("Season narrative not generated yet.");

            return Ok(new
            {
                SeasonId = seasonId,
                Narrative = narrative
            });
        }

        [HttpGet("{seasonId:guid}/matches")]
        public async Task<IActionResult> GetMatchesBySeasonId(Guid seasonId)
        {
            var matches = await _getMatchesUseCase.GetMatchesBySeasonId(seasonId);

            return Ok(matches.Select(m => new MatchResponse
            {
                Id = m.Id,
                ClubName = m.Season.Career.ClubName,
                CompetitionName = m.CompetitionName,
                OpponentName = m.OpponentName,
                IsHome = m.IsHome,
                TeamGoals = m.TeamGoals,
                OpponentGoals = m.OpponentGoals,
                LeaguePositionBefore = m.LeaguePositionBefore,
                LeaguePositionAfter = m.LeaguePositionAfter,
                PlayedAt = m.PlayedAt
            }));
        }
    }
}
