﻿using StrikeClient.Models;

namespace StrikeClient
{
    /// <summary>
    /// Rates level API endpoints:
    /// - Get currency exchange rates
    /// </summary>
    public partial class StrikeClient
    {
        public async Task<List<ConversionRate>?> GetExchangeRates(Action<StrikeApiResponse>? logger = null)
        {
            string path = "v1/rates/ticker";

            return await SendGetAsync<List<ConversionRate>>(path, logger)
                        .ConfigureAwait(continueOnCapturedContext: false);
        }
    }
}
