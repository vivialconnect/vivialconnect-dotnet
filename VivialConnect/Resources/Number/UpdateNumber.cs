using Newtonsoft.Json;
using VivialConnect.Http;

namespace VivialConnect.Resources.Number
{
    /// <summary>
    /// Class used to hold properties that will be sent as the body
    /// when submitting update number requests.
    /// </summary>
    /// <seealso cref="VivialConnect.Http.Body" />
    public class UpdateNumber : Body
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="UpdateNumber"/> class from being created.
        /// </summary>
        private UpdateNumber() {}

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateNumber"/> class.
        /// </summary>
        /// <param name="id">Phone number ID.</param>
        public UpdateNumber(int id)
        {
            Id = id;
        }

        /// <summary>
        /// The unique identifier of the phone number object.
        /// </summary>
        /// <value>
        /// ID.
        /// </value>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// The associated phone number as it is 
        /// displayed to users.
        /// </summary>
        /// <value>
        /// Name.
        /// </value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The URL to receive message status callback 
        /// requests for messages sent via the API 
        /// using this associated phone number.
        /// </summary>
        /// <value>
        /// Status Text URL.
        /// </value>
        [JsonProperty("status_text_url")]
        public string StatusTextUrl { get; set; }

        /// <summary>
        /// The URL for receiving SMS messages to the 
        /// associated phone number.
        /// </summary>
        /// <value>
        /// Incoming Text Url.
        /// </value>
        [JsonProperty("incoming_text_url")]
        public string IncomingTextUrl { get; set; }

        /// <summary>
        /// The HTTP method used for the SMS URL requests.
        /// </summary>
        /// <value>
        /// Incoming text method.
        /// </value>
        [JsonProperty("incoming_text_method")]
        public string IncomingTextMethod { get; set; }

        /// <summary>
        /// The URL for receiving SMS messages if SMS 
        /// URL fails. Only valid if you provide a value 
        /// for the SMS URL parameter.
        /// </summary>
        /// <value>
        /// Incoming text fallback URL.
        /// </value>
        [JsonProperty("incoming_text_fallback_url")]
        public string IncomingTextFallbackUrl { get; set; }

        /// <summary>
        /// The HTTP method used for SMS URL fallback requests.
        /// </summary>
        /// <value>
        /// Incoming text fallback method.
        /// </value>
        [JsonProperty("incoming_text_fallback_method")]
        public string IncomingTextFallbackMethod { get; set; }

        /// <summary>
        /// The number to which voice calls will be forwarded.
        /// </summary>
        /// <value>
        /// Voice forwarding number.
        /// </value>
        [JsonProperty("voice_forwarding_number")]
        public string VoiceForwardingNumber { get; set; }

        /// <summary>
        /// The name to be used as the root node when serializing to JSON.
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
