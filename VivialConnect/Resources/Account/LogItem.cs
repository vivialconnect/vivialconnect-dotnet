using Newtonsoft.Json;

namespace VivialConnect.Resources.Account
{
    /// <summary>
    /// Base class for log items.
    /// </summary>
    public abstract class LogItem
    {
        /// <summary>
        /// The account ID.
        /// </summary>
        /// <value>
        /// Account ID.
        /// </value>
        [JsonProperty("account_id")]
        public int AccountId { get; private set; }

        /// <summary>
        /// The account ID and log type.
        /// </summary>
        /// <value>
        /// Account ID and log type.
        /// </value>
        [JsonProperty("account_id_log_type")]
        public string AccountIdLogType { get; private set; }

        /// <summary>
        /// The log timestamp.
        /// </summary>
        /// <value>
        /// Log timestamp.
        /// </value>
        [JsonProperty("log_timestamp")]
        public string LogTimestamp { get; private set; }

        /// <summary>
        /// The type of log.
        /// </summary>
        /// <value>
        /// Type of log.
        /// </value>
        [JsonProperty("log_type")]
        public string LogType { get; private set; }
    }
}
