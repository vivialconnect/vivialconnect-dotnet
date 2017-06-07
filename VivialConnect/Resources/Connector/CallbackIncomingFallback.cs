
namespace VivialConnect.Resources.Connector
{
    /// <summary>
    /// Provides the delivery statuses of messages
    /// sent to or from the account using HTTP
    /// request to a specified URL for
    /// IncomingFallback event types.
    /// </summary>
    public class CallbackIncomingFallback : Callback
    {
        /// <summary>
        /// Incoming Fallback event type.
        /// </summary>
        public override EventTypeEnum EventType
        {
            get { return EventTypeEnum.IncomingFallback; }
        }
    }
}
