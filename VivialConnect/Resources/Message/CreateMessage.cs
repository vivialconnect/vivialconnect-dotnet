﻿using System.Collections.Generic;

using Newtonsoft.Json;
using VivialConnect.Http;

namespace VivialConnect.Resources.Message
{
    /// <summary>
    /// Class used to hold properties that will be sent as the body
    /// when submitting create message requests.
    /// </summary>
    /// <seealso cref="VivialConnect.Http.Body" />
    public class CreateMessage : Body
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMessage"/> class.
        /// </summary>
        /// <param name="toNumber">To number.</param>
        /// <param name="fromNumber">From number.</param>
        public CreateMessage(string toNumber, string fromNumber)
        {
            ToNumber = toNumber;
            FromNumber = fromNumber;
            MediaUrls = new List<string>();
        }

        /// <summary>
        /// The destination phone number for the text message in E.164 
        /// format (+country code +phone number). For US, the format will be 
        /// +1xxxyyyzzzz.
        /// </summary>
        /// <value>
        /// To number.
        /// </value>
        [JsonProperty("to_number")]
        public string ToNumber { get; set; }

        /// <summary>
        /// The origination of the text message using the associated 
        /// phone number you specify in E.164 format (+country code +phone number). 
        /// For US, the format will be +1xxxyyyzzzz.
        /// </summary>
        /// <value>
        /// From number.
        /// </value>
        [JsonProperty("from_number")]
        public string FromNumber { get; set; }

        /// <summary>
        /// The text of the message.
        /// </summary>
        /// <value>
        /// Body.
        /// </value>
        [JsonProperty("body")]
        public string Body { get; set; }

        /// <summary>
        /// The unique identifier of the connector
        /// this message was sent with, if any.
        /// </summary>
        /// <value>
        /// Connector ID.
        /// </value>
        [JsonProperty("connector_id")]
        public int? ConnectorId { get; set; }

        /// <summary>
        /// The URLs of the media you wish to send out with the message. 
        /// GIF, PNG, and JPEG content is currently supported and will be formatted 
        /// correctly for the recipient’s device.
        /// </summary>
        /// <value>
        /// Media urls.
        /// </value>
        [JsonProperty("media_urls")]
        public List<string> MediaUrls { get; set; }

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
                return "message";
            }
        }
    }
}
