using Newtonsoft.Json;

namespace VivialConnect.Resources.Account
{
    /// <summary>
    /// Represents an Account log item.
    /// </summary>
    /// <seealso cref="VivialConnect.Resources.Account.LogItem" />
    public class AccountLogItem : LogItem
    {
        /// <summary>
        /// The account ID and item ID.
        /// </summary>
        /// <value>
        /// Account ID and item ID.
        /// </value>
        [JsonProperty("account_id_item_id")]
        public string AccountIdItemId { get; private set; }

        /// <summary>
        /// The account id and operator id.
        /// </summary>
        /// <value>
        /// Account ID and operator ID.
        /// </value>
        [JsonProperty("account_id_operator_id")]
        public string AccountIdOperatorId { get; private set; }

        /// <summary>
        /// Human-readable description of the log.
        /// </summary>
        /// <value>
        /// Description.
        /// </value>
        [JsonProperty("description")]
        public string Description { get; private set; }

        /// <summary>
        /// The unique ID of item that was affected.
        /// </summary>
        /// <value>
        /// Item ID.
        /// </value>
        [JsonProperty("item_id")]
        public string ItemId { get; private set; }

        /// <summary>
        /// Type of item that was affected. 
        /// Possible values are number, message, account, user.
        /// </summary>
        /// <value>
        /// Type of the item.
        /// </value>
        [JsonProperty("item_type")]
        public string ItemType { get; private set; }

        /// <summary>
        /// A freeform JSON object stroring 
        /// additional data about the log item.
        /// </summary>
        /// <value>
        /// Log data JSON.
        /// </value>
        [JsonProperty("log_data_json")]
        public string LogDataJson { get; private set; }

        /// <summary>
        /// Unique ID of the logs object.
        /// </summary>
        /// <value>
        /// Log ID.
        /// </value>
        [JsonProperty("log_id")]
        public string LogId { get; private set; }

        /// <summary>
        /// Unique ID of operator that caused this log.
        /// </summary>
        /// <value>
        /// Operator ID.
        /// </value>
        [JsonProperty("operator_id")]
        public string OperatorId { get; private set; }

        /// <summary>
        /// The type of operator that caused this log. 
        /// For instance, user for a change made by a logged-in user 
        /// in the ViviaConnect console, account for an log caused 
        /// by an API request by an authenticating Account, admin 
        /// for an log caused by a system.
        /// </summary>
        /// <value>
        /// Type of operator.
        /// </value>
        [JsonProperty("operator_type")]
        public string OperatorType { get; private set; }

        /// <summary>
        /// The originating system or interface that caused the 
        /// log. web for logs caused by user action in the VivialConnect 
        /// console. api for logs caused through a request to the REST API. 
        /// system for logs caused by an automated or internal system.
        /// </summary>
        /// <value>
        /// Origin.
        /// </value>
        [JsonProperty("origin")]
        public string Origin { get; private set; }
    }
}
