using Newtonsoft.Json;

namespace VivialConnect.Resources
{
    /// <summary>
    /// Interface for Paging query string parameter.
    /// </summary>
    public interface IPagingQueryParams
    {
        /// <summary>
        /// The page number.
        /// </summary>
        /// <value>
        /// Page number.
        /// </value>
        [JsonProperty("page")]
        int Page { get; set; }

        /// <summary>
        /// The size of the page.
        /// </summary>
        /// <value>
        /// Size of the page.
        /// </value>
        [JsonProperty("limit")]
        int PageSize { get; set; }
    }
}
