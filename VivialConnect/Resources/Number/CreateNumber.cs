using Newtonsoft.Json;
using VivialConnect.Http;

namespace VivialConnect.Resources.Number
{
    /// <summary>
    /// Class used to hold properties that will be sent as the body
    /// when submitting create phone number requests.
    /// </summary>
    /// <seealso cref="VivialConnect.Http.Body" />
    public class CreateNumber : Body
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="CreateNumber"/> class from being created.
        /// </summary>
        private CreateNumber() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateNumber"/> class.
        /// </summary>
        /// <param name="phoneNumber">Phone number.</param>
        /// <param name="phoneNumberType">PhoneNumberType.</param>
        public CreateNumber(string phoneNumber, PhoneNumberTypeEnum phoneNumberType)
        {
            PhoneNumber = phoneNumber;
            PhoneNumberType = phoneNumberType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateNumber"/> class.
        /// </summary>
        /// <param name="areaCode">Area code.</param>
        /// <param name="phoneNumberType">Type of phone number.</param>
        public CreateNumber(int areaCode, PhoneNumberTypeEnum phoneNumberType)
        {
            AreaCode = areaCode;
            PhoneNumberType = phoneNumberType;
        }

        /// <summary>
        /// The area code.
        /// </summary>
        /// <value>
        /// Area code.
        /// </value>
        [JsonProperty("area_code")]
        public int? AreaCode { get; set; }

        /// <summary>
        /// The unique identifier of the connector
        /// the message was sent over, if any.
        /// </summary>
        /// <value>
        /// Connector ID.
        /// </value>
        [JsonProperty("connector_id")]
        public int? ConnectorId { get; set; }

        /// <summary>
        /// The HTTP method used for SMS Fallback URL requests.
        /// </summary>
        /// <value>
        /// Incoming text fallback method.
        /// </value>
        [JsonProperty("incoming_text_fallback_method")]
        public string IncomingTextFallbackMethod { get; set; }

        /// <summary>
        /// The URL for receiving SMS messages if SMS URL 
        /// fails. Only valid if you provide a value for 
        /// the SMS URL parameter.
        /// </summary>
        /// <value>
        /// Incoming text fallback URL.
        /// </value>
        [JsonProperty("incoming_text_fallback_url")]
        public string IncomingTextFallbackUrl { get; set; }

        /// <summary>
        /// The HTTP method used for the SMS URL requests.
        /// </summary>
        /// <value>
        /// Incoming text method.
        /// </value>
        [JsonProperty("incoming_text_method")]
        public string IncomingTextMethod { get; set; }

        /// <summary>
        /// The URL for receiving SMS messages to the 
        /// associated phone number.
        /// </summary>
        /// <value>
        /// Incoming Text URL.
        /// </value>
        [JsonProperty("incoming_text_url")]
        public string IncomingTextUrl { get; set; }

        /// <summary>
        /// Phone number as it is displayed to the user.
        /// </summary>
        /// <value>
        /// Name.
        /// </value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The phone number.
        /// </summary>
        /// <value>
        /// Phone number.
        /// </value>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The type of phone number.
        /// </summary>
        /// <value>
        /// Type of phone number.
        /// </value>
        [JsonProperty("phone_number_type")]
        public virtual PhoneNumberTypeEnum PhoneNumberType { get; set; }

        /// <summary>
        /// URL to receive messages status callback
        /// requests for messages sent via the API
        /// using this associated phone number.
        /// </summary>
        /// <value>
        /// Status text URL.
        /// </value>
        [JsonProperty("status_text_url")]
        public string StatusTextUrl { get; set; }

        /// <summary>
        /// Gets the name to be used as the root node when serializing to JSON.
        /// </summary>
        /// <value>
        /// Root name.
        /// </value>
        public override string RootName
        {
            get
            {
                return "phone_number";
            }
        }
    }
}
