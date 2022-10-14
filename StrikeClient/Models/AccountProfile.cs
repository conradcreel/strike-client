using System.Text.Json.Serialization;

namespace StrikeClient.Models
{
    public class AccountProfile
    {
        [JsonPropertyName("handle")]
        public string? Handle { get; set; }

        [JsonPropertyName("avatarUrl")]
        public string? Avatar { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("canReceive")]
        public bool CanReceiveFunds { get; set; }

        [JsonPropertyName("currencies")]
        public List<AccountCurrency> Currencies = new List<AccountCurrency>();
    }

    public class AccountCurrency
    {
        [JsonPropertyName("currency")]
        public string? CurrencyCode { get; set; }

        [JsonPropertyName("isDefaultCurrency")]
        public bool IsDefault { get; set; }

        [JsonPropertyName("isAvailable")]
        public bool IsAvailable { get; set; }

        [JsonPropertyName("isInvoiceable")]
        public bool IsInvoiceable { get; set; }
    }
}
