using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VivialConnect.Resources.Connector
{
    /// <summary>
    /// Event type enumeration.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EventTypeEnum
    {
        /// <summary>
        /// Incoming
        /// </summary>
        [EnumMember(Value = "incoming")]
        Incoming,
        /// <summary>
        /// Incoming Fallback
        /// </summary>
        [EnumMember(Value = "incoming_fallback")]
        IncomingFallback,
        /// <summary>
        /// Status
        /// </summary>
        [EnumMember(Value = "status")]
        Status
    }
}
