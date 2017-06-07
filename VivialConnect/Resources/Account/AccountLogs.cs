using System.Collections.Generic;

using Newtonsoft.Json;

namespace VivialConnect.Resources.Account
{
    /// <summary>
    /// Holds the account logs retrieved from the API.
    /// </summary>
    /// <seealso cref="VivialConnect.Resources.Account.Logs" />
    public class AccountLogs : Logs
    {
        /// <summary>
        /// The log items.
        /// </summary>
        /// <value>
        /// Log items.
        /// </value>
        [JsonProperty("log_items")]
        public List<AccountLogItem> LogItems { get; private set; }
    }
}
