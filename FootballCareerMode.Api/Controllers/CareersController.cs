using FootballCareerMode.Application.DTOs.Careers;
using FootballCareerMode.Application.UseCases.Careers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballCareerMode.Api.Controllers
{
    [Route("api/v1/careers")]
    [ApiController]
    public class CareersController : ControllerBase
    {
        private readonly CreateCareerService _createCareerService;

        public CareersController(CreateCareerService createCareerService)
        {
            _createCareerService = createCareerService;
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
    }
}
