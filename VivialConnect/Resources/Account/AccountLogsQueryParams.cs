using System;

using Newtonsoft.Json;

namespace VivialConnect.Resources.Account
{
    /// <summary>
    /// Holds all valid query string parameters when retrieving logs.
    /// </summary>
    /// <seealso cref="VivialConnect.Resources.Account.LogsQueryParams" />
    public class AccountLogsQueryParams : LogsQueryParams
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountLogsQueryParams"/> class.
        /// </summary>
        /// <param name="startTime">Start date and time.</param>
        /// <param name="endTime">End date and time.</param>
        public AccountLogsQueryParams(DateTime startTime, DateTime endTime) : base(startTime, endTime)
        { }

        /// <summary>
        /// The unique ID of item that was affected.
        /// </summary>
        /// <value>
        /// Item ID.
        /// </value>
        [JsonProperty("item_id")]
        public int? ItemId { get; set; }
    }
}
