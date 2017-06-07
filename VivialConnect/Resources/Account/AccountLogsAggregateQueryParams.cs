using System;

using Newtonsoft.Json;

namespace VivialConnect.Resources.Account
{
    /// <summary>
    /// Holds all valid query string parameters when retrieving aggregate logs.
    /// </summary>
    /// <seealso cref="VivialConnect.Resources.Account.LogsQueryParams" />
    public class AccountLogsAggregateQueryParams : LogsQueryParams
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountLogsAggregateQueryParams"/> class.
        /// </summary>
        /// <param name="startTime">Start date and time.</param>
        /// <param name="endTime">End date and time.</param>
        /// <param name="aggregatorType">Type of aggregator.</param>
        public AccountLogsAggregateQueryParams(DateTime startTime, DateTime endTime, AggregatorTypeEnum aggregatorType) : base(startTime, endTime)
        {
            AggregatorType = aggregatorType;
        }

        /// <summary>
        /// The type of the aggregator. If present with valid 
        /// values, then it will give aggregate map. Else it will give 
        /// aggregate total counts. Valid values are: minutes, hours, days, 
        /// months, years.
        /// </summary>
        /// <value>
        /// Type of aggregator.
        /// </value>
        [JsonProperty("aggregator_type")]
        public AggregatorTypeEnum AggregatorType { get; set; }
    }
}
