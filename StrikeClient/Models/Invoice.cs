using System.Text.Json.Serialization;

namespace StrikeClient.Models
{
    public class Invoice
    {
        [JsonPropertyName("invoiceId")]
        public string? InvoiceId { get; set; }

        [JsonPropertyName("amount")]
        public InvoiceAmount? InvoiceAmount { get; set; }

        [JsonPropertyName("state")]
        public string? State { get; set; }

        [JsonPropertyName("created")]
        public string? CreatedDate { get; set; }

        [JsonPropertyName("correlationId")]
        public string? CorrelationId { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("issuerId")]
        public string? IssuerId { get; set; }

        [JsonPropertyName("receiverId")]
        public string? ReceiverId { get; set; }

        [JsonPropertyName("payerId")]
        public string? PayerId { get; set; }
    }

    public class InvoiceAmount
    {
        [JsonPropertyName("currency")]
        public string? Currency { get; set; }

        [JsonPropertyName("amount")]
        public string? Amount { get; set; }
    }
}
