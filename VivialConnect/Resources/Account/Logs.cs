using Newtonsoft.Json;

namespace VivialConnect.Resources.Account
{
    /// <summary>
    /// Base class for detailed and aggregate account logs.
    /// </summary>
    /// <seealso cref="VivialConnect.Resources.ResourceEntity" />
    public abstract class Logs : ResourceEntity
    {
        /// <summary>
        /// The last key used for pagination. Can be sent with 
        /// next request as start_key to get next set of results.
        /// </summary>
        /// <value>
        /// Last key.
        /// </value>
        [JsonProperty("last_key")]
        public string LastKey { get; private set; }
    }
}
