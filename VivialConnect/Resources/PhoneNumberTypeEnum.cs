using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VivialConnect.Resources
{
    /// <summary>
    /// Phone number type enumeration.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PhoneNumberTypeEnum
    {
        /// <summary>
        /// Local
        /// </summary>
        [EnumMember(Value = "local")]
        Local,
        /// <summary>
        /// Toll free
        /// </summary>
        [EnumMember(Value = "tollfree")]
        TollFree
    }
}
