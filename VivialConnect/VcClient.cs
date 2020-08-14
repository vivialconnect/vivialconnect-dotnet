using VivialConnect.Exceptions;
using VivialConnect.Http;
using VivialConnect.Mappings;

namespace VivialConnect
{
    /// <summary>
    /// VcClient used to store API elements and generate REST client.
    /// </summary>
    public class VcClient
    {
        private static int _accountId;
        private static string _apiKey;
        private static string _apiSecret;
        private static string _apiBaseUrl;
        private static VcRestClient _restClient;

        /// <summary>
        /// Prevents a default instance of the <see cref="VcClient"/> class from being created.
        /// </summary>
        private VcClient() { }

        /// <summary>
        /// Initializes the VcRestClient.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="apiKey">API key.</param>
        /// <param name="apiSecret">API secret.</param>
        /// <param name="apiBaseUrl">API base URL.</param>
        public static void Init(int accountId, string apiKey, string apiSecret, string apiBaseUrl= "https://api.vivialconnect.net/api/v1.0/")
        {
            _accountId = accountId;
            _apiKey = apiKey;
            _apiSecret = apiSecret;
            _apiBaseUrl = apiBaseUrl;
            _restClient = null;
        }

        /// <summary>
        /// The REST client.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="AuthenticationException">Initialize VcClient before attempting to use any Resource.</exception>
        public static VcRestClient GetRestClient()
        {
            if (_restClient != null)
            {
                return _restClient;
            }

            if (string.IsNullOrWhiteSpace(_apiKey) ||
                string.IsNullOrWhiteSpace(_apiSecret))
            {
                throw new AuthenticationException(
                    "Initialize VcClient before attempting to use any Resource."
                    );
            }

            _restClient = new VcRestClient(_apiKey, _apiSecret, _apiBaseUrl);
            return _restClient;
        }

        /// <summary>
        /// The Account ID.
        /// </summary>
        /// <value>
        /// Account ID.
        /// </value>
        public static int AccountId
        {
            get { return _accountId; }
        }

        /// <summary>
        /// The API base URL.
        /// </summary>
        /// <value>
        /// API base URL.
        /// </value>
        public static string ApiBaseUrl
        {
            get { return _apiBaseUrl; }
        }
    }
}
