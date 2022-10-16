using StrikeClient.Models;
using StrikeClient.Request;

namespace StrikeClient
{
    /// <summary>
    /// Subscriptions level API endpoints:
    /// - Get Subscriptions
    /// - Create Subscriptions
    /// - Get Subscription
    /// - Update a subscription (TODO)
    /// - Delete a subscription (TODO)
    /// </summary>
    public partial class StrikeClient
    {
        public async Task<List<Subscription>?> GetSubscriptions(Action<StrikeApiResponse>? logger = null)
        {
            string path = "v1/subscriptions";

            return await SendGetAsync<List<Subscription>>(path, logger)
                        .ConfigureAwait(continueOnCapturedContext: false);
        }

        public async Task<Subscription?> CreateSubscription(string webhookUrl, string version, string secret, bool enabled, List<string> eventTypes, Action<StrikeApiResponse>? logger = null)
        {
            string path = "v1/subscriptions";

            return await SendPostAsync<CreateSubscriptionRequest, Subscription>(path, new CreateSubscriptionRequest
            {
                Enabled = enabled,
                Secret = secret,
                WebhookUrl = webhookUrl,
                Version = version,
                Types = eventTypes
            }, logger).ConfigureAwait(continueOnCapturedContext: false);
        }

        public async Task<Subscription?> GetSubscription(string subscriptionId, Action<StrikeApiResponse>? logger = null)
        {
            string path = $"v1/subscriptions/{subscriptionId}";

            return await SendGetAsync<Subscription>(path, logger).ConfigureAwait(continueOnCapturedContext: false);
        }
    }
}
