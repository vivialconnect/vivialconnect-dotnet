using System;

namespace VivialConnect.Resources.Connector
{
    /// <summary>
    /// Provides the delivery statuses of messages
    /// sent to or from the account using HTTP
    /// request to a specified URL.
    /// </summary>
    public abstract class Callback : ICallback
    {
        /// <summary>
        /// The date created.
        /// </summary>
        /// <value>
        /// Date created.
        /// </value>
        public DateTime? DateCreated { get; private set; }

        /// <summary>
        /// The date modified.
        /// </summary>
        /// <value>
        /// Date modified.
        /// </value>
        public DateTime? DateModified { get; private set; }

        /// <summary>
        /// The event type the callback applies
        /// to 'incoming', 'incoming_fallback'
        /// or 'status'.
        /// </summary>
        /// <value>
        /// Event type.
        /// </value>
        public abstract EventTypeEnum EventType { get; }

        /// <summary>
        /// The message type the callback applies
        /// to 'text', 'voice'.
        /// </summary>
        /// <value>
        /// Message type.
        /// </value>
        public MessageTypeEnum MessageType { get; set; }

        /// <summary>
        /// The HTTP method used for the callback.
        /// </summary>
        /// <value>
        /// Method.
        /// </value>
        public string Method { get; set; }

        /// <summary>
        /// The URL the callback will hit.
        /// </summary>
        /// <value>
        /// URL.
        /// </value>
        public string Url { get; set; }
    }
}
