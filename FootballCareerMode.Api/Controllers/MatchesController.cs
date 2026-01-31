using FootballCareerMode.Application.DTOs.Matches;
using FootballCareerMode.Application.UseCases.Matches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballCareerMode.Api.Controllers
{
    [Route("api/v1/seasons/{seasonId:guid}/matches")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly SubmitMatchService _submitMatchService;

        public MatchesController(SubmitMatchService submitMatchService)
        {
            _submitMatchService = submitMatchService;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitMatch(
            Guid seasonId,
            [FromBody] SubmitMatchRequest request)
        {
            if (seasonId != request.SeasonId)
                return BadRequest("Season ID mismatch.");

            var matchId = await _submitMatchService.SubmitAsync(request);

            return (CreatedAtAction(
                nameof(SubmitMatch),
                new { matchId },
                new { matchId }));
        }
    }
}
