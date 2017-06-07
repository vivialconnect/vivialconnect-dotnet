using Newtonsoft.Json;

namespace VivialConnect.Resources
{
    /// <summary>
    /// Interface for Contains query string parameter.
    /// </summary>
    public interface  IContainsQueryParams
    {
        /// <summary>
        /// The Contains query string parameter.
        /// </summary>
        /// <value>
        /// Contains query string parameter.
        /// </value>
        [JsonProperty("contains")]
        string Contains { get; set; }
    }
}
