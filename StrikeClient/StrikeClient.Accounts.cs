using StrikeClient.Models;

namespace StrikeClient
{
    /// <summary>
    /// Account level API endpoints: 
    ///  - Fetch profile by handle (username)
    ///  - Fetch profile by id
    /// </summary>
    public partial class StrikeClient
    {
        /// <summary>
        /// Fetch public account profile info by id
        /// Required scopes: partner.account.profile.read
        /// </summary>
        /// <param name="id">The user's Strike UUID</param>
        /// <param name="logger"></param>
        /// <returns></returns>
        public async Task<AccountProfile?> GetProfileById(string id, Action<StrikeApiResponse>? logger = null)
        {
            string path = $"v1/accounts/{id}/profile";

            return await SendGetAsync<AccountProfile>(path, logger).ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Fetch public account profile info by handle
        /// Required scopes: partner.account.profile.read
        /// </summary>
        /// <param name="handle">The user's Strike username</param>
        /// <param name="logger"></param>
        /// <returns></returns>
        public async Task<AccountProfile?> GetProfileByHandle(string handle, Action<StrikeApiResponse>? logger = null)
        {
            string path = $"v1/accounts/handle/{handle}/profile";

            return await SendGetAsync<AccountProfile>(path, logger).ConfigureAwait(continueOnCapturedContext: false);
        }
    }
}
