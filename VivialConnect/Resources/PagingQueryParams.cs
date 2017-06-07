using Newtonsoft.Json;
using VivialConnect.Http;

namespace VivialConnect.Resources
{
    /// <summary>
    /// Paging query string parameter class.
    /// </summary>
    /// <seealso cref="VivialConnect.Http.QueryParams" />
    /// <seealso cref="VivialConnect.Resources.IPagingQueryParams" />
    public class PagingQueryParams : QueryParams, IPagingQueryParams
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="PagingQueryParams"/> class from being created.
        /// </summary>
        private PagingQueryParams() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagingQueryParams"/> class.
        /// </summary>
        /// <param name="pageNumber">Page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        public PagingQueryParams(int pageNumber, int pageSize)
        {
            Page = pageNumber;
            PageSize = pageSize;
        }

        /// <summary>
        /// The page number.
        /// </summary>
        /// <value>
        /// Page number.
        /// </value>
        [JsonProperty("page")]
        public int Page { get; set; }

        /// <summary>
        /// The size of the page.
        /// </summary>
        /// <value>
        /// Size of the page.
        /// </value>
        [JsonProperty("limit")]
        public int PageSize { get; set; }        
    }
}
