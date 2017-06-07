using System;

using Newtonsoft.Json;

namespace VivialConnect.Resources.Connector
{
    public interface ICallback
    {
        /// <summary>
        /// The date created.
        /// </summary>
        /// <value>
        /// Date created.
        /// </value>
        [JsonProperty("date_created")]
        DateTime? DateCreated { get; }

        /// <summary>
        /// The date modified.
        /// </summary>
        /// <value>
        /// Date modified.
        /// </value>
        [JsonProperty("date_modified")]
        DateTime? DateModified { get; }

        /// <summary>
        /// The event type the callback applies
        /// to 'incoming', 'incoming_fallback'
        /// or 'status'.
        /// </summary>
        /// <value>
        /// Event type.
        /// </value>
        [JsonProperty("event_type")]
        EventTypeEnum EventType { get;}

        /// <summary>
        /// The message type the callback applies
        /// to 'text', 'voice'.
        /// </summary>
        /// <value>
        /// Message type.
        /// </value>
        [JsonProperty("message_type")]
        MessageTypeEnum MessageType { get; set; }

        /// <summary>
        /// The HTTP method used for the callback.
        /// </summary>
        /// <value>
        /// Method.
        /// </value>
        [JsonProperty("method")]
        string Method { get; set; }

        /// <summary>
        /// The URL the callback will hit.
        /// </summary>
        /// <value>
        /// URL.
        /// </value>
        [JsonProperty("url")]
        string Url { get; set; }
    }
}
