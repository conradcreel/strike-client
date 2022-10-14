using System.Text.Json.Serialization;

namespace StrikeClient.Models
{
    public class WebhookData
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("eventType")]
        public string? EventType { get; set; }

        [JsonPropertyName("webhookVersion")]
        public string? WebhookVersion { get; set; }

        [JsonPropertyName("data")]
        public WebhookEntityData? entityData { get; set; }

        [JsonPropertyName("created")]
        public string? CreatedDate { get; set; }

        [JsonPropertyName("deliverySuccess")]
        public bool DeliverySuccess { get; set; }
    }

    public class WebhookEntityData
    {
        [JsonPropertyName("entityId")]
        public string? EntityId { get; set; }

        [JsonPropertyName("changes")]
        public List<string> Changes { get; set; } = new List<string>();
    }
}
