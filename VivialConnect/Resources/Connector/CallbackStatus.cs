
namespace VivialConnect.Resources.Connector
{
    /// <summary>
    /// Provides the delivery statuses of messages
    /// sent to or from the account using HTTP
    /// request to a specified URL for
    /// Status event types.
    /// </summary>
    public class CallbackStatus : Callback
    {
        /// <summary>
        /// Status event type.
        /// </summary>
        public override EventTypeEnum EventType
        {
            get { return EventTypeEnum.Status; }
        }
    }
}
