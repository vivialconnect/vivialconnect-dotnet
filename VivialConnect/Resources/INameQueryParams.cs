using Newtonsoft.Json;

namespace VivialConnect.Resources
{
    /// <summary>
    /// Interface for Name query string parameter.
    /// </summary>
    public interface INameQueryParams
    {
        /// <summary>
        /// The Name query string parameter.
        /// </summary>
        /// <value>
        /// Name query string parameter.
        /// </value>
        [JsonProperty("name")]
        string Name { get; set; }
    }
}
