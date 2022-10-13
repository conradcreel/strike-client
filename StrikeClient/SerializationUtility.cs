using System.Text.Json.Serialization;
using System.Text.Json;

namespace StrikeClient
{
    public static class SerializationUtility
    {
        public static JsonSerializerOptions SerializerOptions => new JsonSerializerOptions
        {
            IgnoreReadOnlyFields = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        };
    }
}
