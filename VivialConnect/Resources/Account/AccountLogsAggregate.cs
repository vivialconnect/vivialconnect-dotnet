using System.Collections.Generic;

using Newtonsoft.Json;

namespace VivialConnect.Resources.Account
{
    /// <summary>
    /// Holds the aggregate account logs retrieved from the API.
    /// </summary>
    /// <seealso cref="VivialConnect.Resources.Account.Logs" />
    public class AccountLogsAggregate : Logs
    {
        /// <summary>
        /// The aggregate log items.
        /// </summary>
        /// <value>
        /// Aggregate log items.
        /// </value>
        [JsonProperty("log_items")]
        public List<AccountLogAggregateItem> LogAggregateItems { get; private set; }
    }
}
