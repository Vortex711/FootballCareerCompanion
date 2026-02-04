using FootballCareerCompanion.Application.DTOs.Matches;
using FootballCareerCompanion.Application.UseCases.Matches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballCareerCompanion.Api.Controllers
{
    [Route("api/v1/seasons/{seasonId:guid}/matches")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly SubmitMatchUseCase _submitMatchService;
        private readonly GetMatchNarrativeUseCase _getMatchNarrativeService;

        public MatchesController(SubmitMatchUseCase submitMatchService, GetMatchNarrativeUseCase getMatchNarrativeService)
        {
            _submitMatchService = submitMatchService;
            _getMatchNarrativeService = getMatchNarrativeService;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitMatch(
            Guid seasonId,
            [FromBody] SubmitMatchRequest request)
        {
            if (seasonId != request.SeasonId)
                return BadRequest("Season ID mismatch.");

            var matchId = await _submitMatchService.SubmitAsync(request);

            return CreatedAtAction(
                nameof(SubmitMatch),
                new { matchId },
                new { matchId });
        }

        [HttpGet("{matchId}/narrative")]
        public async Task<IActionResult> GetMatchNarrative(Guid matchId)
        {
            var narrative = await _getMatchNarrativeService.GetNarrativeAsync(matchId);

            if (narrative == null)
                return NotFound("Match narrative not generated yet.");

            return Ok(new
            {
                MatchId = matchId,
                Narrative = narrative
            });
        }

    }
}
