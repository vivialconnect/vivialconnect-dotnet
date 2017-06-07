using VivialConnect.Http;

namespace VivialConnect.Resources
{
    /// <summary>
    /// Contains query string parameter class.
    /// </summary>
    /// <seealso cref="VivialConnect.Http.QueryParams" />
    /// <seealso cref="VivialConnect.Resources.IContainsQueryParams" />
    public class ContainsQueryParams : QueryParams, IContainsQueryParams
    {
        /// <summary>
        /// The Contains query string parameter.
        /// </summary>
        /// <value>
        /// Contains query string parameter.
        /// </value>
        public string Contains { get; set; }
    }
}
