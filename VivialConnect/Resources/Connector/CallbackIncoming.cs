
namespace VivialConnect.Resources.Connector
{
    /// <summary>
    /// Provides the delivery statuses of messages
    /// sent to or from the account using HTTP
    /// request to a specified URL for
    /// Incoming event types.
    /// </summary>
    public class CallbackIncoming : Callback
    {
        /// <summary>
        /// Incoming event type.
        /// </summary>
        public override EventTypeEnum EventType
        {
            get { return EventTypeEnum.Incoming; }
        }
    }
}
