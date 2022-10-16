using System.Text.Json.Serialization;

namespace StrikeClient.Models
{
    public class Subscription
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("webhookUrl")]
        public string? WebhookUrl { get; set; }

        [JsonPropertyName("webhookVersion")]
        public string? Version { get; set; }

        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        [JsonPropertyName("created")]
        public string? Created { get; set; }

        [JsonPropertyName("eventTypes")]
        public List<string> Types = new List<string>();
    }
}
