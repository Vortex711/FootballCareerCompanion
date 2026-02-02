using FootballCareerMode.Application.UseCases.Seasons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballCareerMode.Api.Controllers
{
    [Route("api/v1/seasons")]
    [ApiController]
    public class SeasonsController : ControllerBase
    {
        private readonly SeasonNarrativeService _SeasonNarrativeService;

        public SeasonsController(SeasonNarrativeService SeasonNarrativeService)
        {
            _SeasonNarrativeService = SeasonNarrativeService;
        }

        [HttpPost("{seasonId:guid}/narrative")]
        public async Task<IActionResult> GenerateSeasonNarrative(Guid seasonId)
        {
            await _SeasonNarrativeService.GenerateNarrativeAsync(seasonId);

            return Accepted(new
            {
                SeasonId = seasonId,
                Message = "Season narrative generation started."
            });
        }

        [HttpGet("{seasonId:guid}/narrative")]
        public async Task<IActionResult> GetSeasonNarrative(Guid seasonId)
        {
            var narrative = await _SeasonNarrativeService.GetNarrativeAsync(seasonId);

            if (narrative == null)
                return NotFound("Season narrative not generated yet.");

            return Ok(new
            {
                SeasonId = seasonId,
                Narrative = narrative
            });
        }
    }
}
