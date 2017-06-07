using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VivialConnect.Resources.Connector
{
    /// <summary>
    /// Message type enumeration.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum  MessageTypeEnum
    {
        /// <summary>
        /// Text
        /// </summary>
        [EnumMember(Value = "text")]
        Text,
        /// <summary>
        /// Voice
        /// </summary>
        [EnumMember(Value = "voice")]
        Voice
    }
}
