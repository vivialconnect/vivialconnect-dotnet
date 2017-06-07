using System;

using Newtonsoft.Json;
using VivialConnect.Http;

namespace VivialConnect.Resources.Account
{
    /// <summary>
    /// Base class that holds all valid query string parameters when retrieving logs.
    /// </summary>
    /// <seealso cref="VivialConnect.Http.QueryParams" />
    public abstract class LogsQueryParams : QueryParams
    {
        private DateTime _startTime;
        private DateTime _endTime;

        /// <summary>
        /// Prevents a default instance of the <see cref="LogsQueryParams"/> class from being created.
        /// </summary>
        private LogsQueryParams() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogsQueryParams"/> class.
        /// </summary>
        /// <param name="startTime">Start date and time.</param>
        /// <param name="endTime">End date and time.</param>
        public LogsQueryParams(DateTime startTime, DateTime endTime)
        {
            _startTime = startTime;
            _endTime = endTime;
        }

        /// <summary>
        /// The start date and time. Format used is ISO 8601 
        /// as YYYYMMDDThhmmssZ , ISO 8601 format without - and :.
        /// </summary>
        /// <value>
        /// Start date and time.
        /// </value>
        [JsonProperty("start_time")]
        public string StartTime
        {
            get { return Utils.FormatLogTimestamp(_startTime); }
        }

        /// <summary>
        /// The end date and time. Format used is ISO 8601 
        /// as YYYYMMDDThhmmssZ , ISO 8601 format without - and :.
        /// </summary>
        /// <value>
        /// End date and time.
        /// </value>
        [JsonProperty("end_time")]
        public string EndTime
        {
            get { return Utils.FormatLogTimestamp(_endTime); }
        }

        /// <summary>
        /// The log type, as a string. log-types are 
        /// typically of the form ITEM_TYPE.ACTION, where ITEM_TYPE 
        /// is the type of item that was affected and ACTION is what 
        /// happened to it. For example, message.queued.
        /// </summary>
        /// <value>
        /// Type of log.
        /// </value>
        [JsonProperty("log_type")]
        public string LogType { get; set; }

        /// <summary>
        /// Unique ID of operator that caused this log.
        /// </summary>
        /// <value>
        /// Operator ID.
        /// </value>
        [JsonProperty("operator_id")]
        public int? OperatorId { get; set; }

        /// <summary>
        /// The limit used for pagination, number of 
        /// log records to return.
        /// </summary>
        /// <value>
        /// Limit.
        /// </value>
        [JsonProperty("limit")]
        public int? Limit { get; set; }

        /// <summary>
        /// The start key used for pagination, value 
        /// of last_key from previous response.
        /// </summary>
        /// <value>
        /// Start key.
        /// </value>
        [JsonProperty("start_key")]
        public string StartKey { get; set; }

        /// <summary>
        /// The start date and time.
        /// </summary>
        /// <param name="startTime">Start date and time.</param>
        public void SetStartTime(DateTime startTime)
        {
            _startTime = startTime;
        }

        /// <summary>
        /// The end date and time.
        /// </summary>
        /// <param name="endTime">End date and time.</param>
        public void SetEndTime(DateTime endTime)
        {
            _endTime = endTime;
        }
    }
}
