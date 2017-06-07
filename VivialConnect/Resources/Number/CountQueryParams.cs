using Newtonsoft.Json;

namespace VivialConnect.Resources.Number
{
    /// <summary>
    /// Count query string parameter class.
    /// </summary>
    /// <seealso cref="VivialConnect.Resources.NameQueryParams" />
    /// <seealso cref="VivialConnect.Resources.IContainsQueryParams" />
    public class CountQueryParams : NameQueryParams, IContainsQueryParams
    {
        /// <summary>
        /// The Contains query string parameter.
        /// </summary>
        /// <value>
        /// Contains query string parameter.
        /// </value>
        [JsonProperty("contains")]
        public string Contains { get; set; }
    }
}
