using Microsoft.AspNetCore.Mvc;
using StrikeClient;

namespace StrikeWebhook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StrikeWebhookController : ControllerBase
    {
        private readonly ILogger<StrikeWebhookController> _logger;

        public StrikeWebhookController(ILogger<StrikeWebhookController> logger)
        {
            _logger = logger;
        }

        private void Log(StrikeApiResponse apiResponse)
        {
            if (apiResponse.Exception != null)
            {
                _logger.LogCritical(apiResponse.Exception.Message);
            }
            else if (!apiResponse.IsSuccess)
            {
                _logger.LogError($"HTTP {apiResponse.StatusCode} - {apiResponse.Message}");
            }
            else
            {
                // Nothing for now
            }
        }

        [HttpPost("callback")]
        public async Task<IActionResult> StrikeCallback()
        {
            return Ok();
        }
    }
}