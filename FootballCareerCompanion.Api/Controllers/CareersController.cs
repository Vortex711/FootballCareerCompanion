using FootballCareerCompanion.Application.DTOs.Careers;
using FootballCareerCompanion.Application.DTOs.Seasons;
using FootballCareerCompanion.Application.UseCases.Careers;
using FootballCareerCompanion.Application.UseCases.Seasons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballCareerCompanion.Api.Controllers
{
    [Route("api/v1/careers")]
    [ApiController]
    public class CareersController : ControllerBase
    {
        private readonly CreateCareerUseCase _createCareerService;
        private readonly CreateSeasonUseCase _createSeasonService;

        public CareersController(CreateCareerUseCase createCareerService, CreateSeasonUseCase createSeasonService)
        {
            _createCareerService = createCareerService;
            _createSeasonService = createSeasonService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCareer([FromBody] CreateCareerRequest request)
        {
            var careerId = await _createCareerService.CreateCareerAsync(
                request.Name,
                request.ClubName,
                request.ManagerName);

            return CreatedAtAction(
                nameof(CreateCareer),
                new { careerId },
                new { careerId });
        }

        [HttpPost("{careerId:guid}/seasons")]
        public async Task<IActionResult> CreateSeason(
            Guid careerId,
            [FromBody] CreateSeasonRequest request)
        {
            var seasonId = await _createSeasonService.CreateSeason(
                careerId,
                request.Name,
                request.StartDate,
                request.Expectation);

            return CreatedAtAction(
                nameof(CreateSeason),
                new { seasonId },
                new { seasonId });
        }
    }
}
