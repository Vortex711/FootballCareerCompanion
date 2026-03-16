using FootballCareerCompanion.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballCareerCompanion.Api.Controllers
{
    [Route("api/ai-test")]
    [ApiController]
    public class AITestController : ControllerBase
    {
        private readonly ILLMService _llmService;

        public AITestController(ILLMService lLMService)
        {
            _llmService = lLMService;
        }

        [HttpGet]
        public async Task<IActionResult> Test()
        {
            var result = await _llmService.GenerateAsync(
                "Write a one sentence football match commentary.");

            return Ok(result);
        }
    }
}
