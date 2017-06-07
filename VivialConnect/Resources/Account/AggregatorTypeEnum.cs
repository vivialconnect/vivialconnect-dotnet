using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VivialConnect.Resources.Account
{
    /// <summary>
    /// Enumeration for the type of aggregator.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AggregatorTypeEnum
    {
        /// <summary>
        /// The minutes
        /// </summary>
        [EnumMember(Value = "minutes")]
        Minutes,
        /// <summary>
        /// The hours
        /// </summary>
        [EnumMember(Value = "hours")]
        Hours,
        /// <summary>
        /// The days
        /// </summary>
        [EnumMember(Value = "days")]
        Days,
        /// <summary>
        /// The months
        /// </summary>
        [EnumMember(Value = "months")]
        Months,
        /// <summary>
        /// The years
        /// </summary>
        [EnumMember(Value = "years")]
        Years
    }
}
