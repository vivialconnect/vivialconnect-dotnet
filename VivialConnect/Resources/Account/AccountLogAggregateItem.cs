using Newtonsoft.Json;

namespace VivialConnect.Resources.Account
{
    /// <summary>
    /// Log item for aggregate logs.
    /// </summary>
    /// <seealso cref="VivialConnect.Resources.Account.LogItem" />
    public class AccountLogAggregateItem : LogItem
    {
        /// <summary>
        /// The log count.
        /// </summary>
        /// <value>
        /// Log count.
        /// </value>
        [JsonProperty("log_count")]
        public int LogCount { get; private set; }
    }
}
