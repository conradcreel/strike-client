using System.Text.Json.Serialization;

namespace StrikeClient.Models
{
    public class Invoices
    {
        [JsonPropertyName("items")]
        public List<Invoice> Items { get; set; } = new List<Invoice>();

        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}
