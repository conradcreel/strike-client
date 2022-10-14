using Microsoft.AspNetCore.Mvc;
using StrikeClient;
using StrikeClient.Models;

namespace StrikeWebhook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StrikeWebhookController : ControllerBase
    {
        private readonly ILogger<StrikeWebhookController> _logger;
        private readonly StrikeConfiguration _StrikeConfiguration;

        public StrikeWebhookController(ILogger<StrikeWebhookController> logger, StrikeConfiguration strikeConfiguration)
        {
            _logger = logger;
            _StrikeConfiguration = strikeConfiguration;
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
                _logger.LogInformation($"HTTP {apiResponse.StatusCode} - {apiResponse.Message}");
            }
        }

        private async Task HandleMessage(WebhookData webhook)
        {
            switch (webhook.EventType)
            {
                case "invoice.created":
                    // TODO
                    break;
                case "invoice.updated":
                    // TODO
                    break;
                default:
                    break;
            }
        }

        [HttpPost("callback")]
        public async Task<IActionResult> StrikeCallback([FromBody] WebhookData model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var challenge = Request.Headers["X-Webhook-Signature"];
            if (string.IsNullOrWhiteSpace(challenge))
            {
                return BadRequest();
            }

            // NOTE: Should queue the message received and then move the
            // following method to your event handler. 
            await HandleMessage(model).ConfigureAwait(continueOnCapturedContext: false);

            return Ok();
        }
    }
}