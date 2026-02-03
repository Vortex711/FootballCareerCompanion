using FootballCareerCompanion.Application.UseCases.Seasons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballCareerCompanion.Api.Controllers
{
    [Route("api/v1/seasons")]
    [ApiController]
    public class SeasonsController : ControllerBase
    {
        private readonly SeasonNarrativeService _SeasonNarrativeService;
        private readonly EndSeasonService _endSeasonService;

        public SeasonsController(
            SeasonNarrativeService SeasonNarrativeService, 
            EndSeasonService endSeasonService)
        {
            _SeasonNarrativeService = SeasonNarrativeService;
            _endSeasonService = endSeasonService;
        }

        [HttpPost("{seasonId:guid}/end")]
        public async Task<IActionResult> EndSeason(
            Guid seasonId,
            [FromBody] DateTime endDate)
        {
            await _endSeasonService.EndSeasonAsync(
                seasonId,
                endDate);

            return NoContent();
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
