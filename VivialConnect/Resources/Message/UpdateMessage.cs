using Newtonsoft.Json;
using VivialConnect.Http;

namespace VivialConnect.Resources.Message
{
    /// <summary>
    /// Class used to hold properties that will be sent as the body
    /// when submitting update message requests.
    /// </summary>
    /// <seealso cref="VivialConnect.Http.Body" />
    public class UpdateMessage : Body
    {
        /// <summary>
        /// The unique identifier of the text message object.
        /// </summary>
        /// <value>
        /// ID.
        /// </value>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// The text of the message.
        /// </summary>
        /// <value>
        /// Body.
        /// </value>
        [JsonProperty("body")]
        public string Body { get { return string.Empty; } }

        /// <summary>
        /// The name to be used as the root node when 
        /// serializing to JSON.
        /// </summary>
        /// <value>
        /// Root name.
        /// </value>
        public override string RootName
        {
            get
            {
                return "message";
            }
        }
    }
}
