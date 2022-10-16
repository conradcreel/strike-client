using System.Text.Json.Serialization;

namespace StrikeClient.Models
{
    public class InvoiceQuote
    {
        [JsonPropertyName("quoteId")]
        public string? QuoteId { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("lnInvoice")]
        public string? BOLT11 { get; set; }

        [JsonPropertyName("onchainAddress")]
        public string? OnChainAddress { get; set; }

        [JsonPropertyName("expiration")]
        public string? Expiration { get; set; }

        [JsonPropertyName("expirationInSec")]
        public int ExpirationInSeconds { get; set; }

        [JsonPropertyName("targetAmount")]
        public InvoiceAmount? TargetAmount { get; set; }

        [JsonPropertyName("sourceAmount")]
        public InvoiceAmount? SourceAmount { get; set; }

        [JsonPropertyName("conversionRate")]
        public ConversionRate? ConversionRate { get; set; }
    }

    public class ConversionRate
    {
        [JsonPropertyName("amount")]
        public string? Amount { get; set; }

        [JsonPropertyName("sourceCurrency")]
        public string? SourceCurrency { get; set; }

        [JsonPropertyName("TargetCurrency")]
        public string? TargetCurrency { get; set; }
    }
}
