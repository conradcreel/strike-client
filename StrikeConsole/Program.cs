using StrikeClient;
using System.Net.Http.Headers;
using System.Text.Json;

namespace StrikeConsole
{
    internal class Program
    {
        static HttpClient _Http = new HttpClient();

        private static readonly string _Accept = "application/json";
        private static readonly string _Scheme = "Bearer";
        private static readonly string _Endpoint = "https://api.strike.me/";

        private static readonly string _ApiKey = "<YOUR_API_KEY_HERE>";

        static async Task Main(string[] args)
        {
            var config = new StrikeConfiguration
            {
                Endpoint = _Endpoint,
                ApiKey = _ApiKey
            };

            ConfigHttp(config);
            var client = new StrikeClient.StrikeClient(config, _Http);

            await GetAccountProfile(client).ConfigureAwait(continueOnCapturedContext: false);
        }

        private static void ConfigHttp(StrikeConfiguration config)
        {
            _Http.BaseAddress = new Uri(config.Endpoint);
            _Http.DefaultRequestHeaders.Add("Accept", _Accept);
            _Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_Scheme, config.ApiKey);
        }

        private static async Task GetAccountProfile(StrikeClient.StrikeClient client)
        {
            const string username = "cyco";

            await client.GetProfileByHandle(username, Log).ConfigureAwait(continueOnCapturedContext: false);
        }

        private static void Log(StrikeApiResponse apiResponse)
        {
            if (apiResponse.Exception != null)
            {
                Console.Error.WriteLine(apiResponse.Exception.Message);
            }
            else if (!apiResponse.IsSuccess)
            {
                Console.Error.WriteLine($"HTTP {apiResponse.StatusCode} - {apiResponse.Message}");
            }
            else
            {
                Console.WriteLine($"HTTP {apiResponse.StatusCode} - {apiResponse.Message}");
            }
        }
    }
}