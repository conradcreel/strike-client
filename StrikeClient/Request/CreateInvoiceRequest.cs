using StrikeClient.Models;
using System.Text.Json.Serialization;

namespace StrikeClient.Request
{
    public class CreateInvoiceRequest
    {
        [JsonPropertyName("correlationId")]
        public string? CorrelationId { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("amount")]
        public InvoiceAmount? Amount { get; set; }
    }
}
