using System.Text.Json.Serialization;

namespace StrikeClient.Request
{
    public class CreateSubscriptionRequest
    {
        [JsonPropertyName("webhookUrl")]
        public string? WebhookUrl { get; set; }

        [JsonPropertyName("webhookVersion")]
        public string? Version { get; set; }

        [JsonPropertyName("secret")]
        public string? Secret { get; set; }

        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        [JsonPropertyName("eventTypes")]
        public List<string> Types { get; set; } = new List<string>();
    }
}
