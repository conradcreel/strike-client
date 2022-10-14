using System.Security.Cryptography;
using System.Text;

namespace StrikeClient
{
    public static class CryptoUtility
    {
        private static readonly Encoding _Encoding = Encoding.UTF8;

        private static string SHA256(string message, string secret)
        {
            using var hasher = new HMACSHA256(_Encoding.GetBytes(secret));
            var hash = hasher.ComputeHash(_Encoding.GetBytes(message));

            return Convert.ToHexString(hash);
        }

        /// <summary>
        /// Validates that the signature came from Strike. 
        /// See more here: https://docs.strike.me/webhooks/signature-verification
        /// </summary>
        /// <param name="challenge">The signature from Strike</param>
        /// <param name="data">The data they hashed</param>
        /// <param name="secret">The secret used when creating this subscription. By convention this client uses the API key</param>
        /// <returns></returns>
        public static bool ValidateStripeSignature(string challenge, string data, string secret)
        {
            var computed = SHA256(data, secret);

            return challenge == computed;
        }
    }
}
