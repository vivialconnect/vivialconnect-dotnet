using VivialConnect.Http;

namespace VivialConnect.Resources
{
    /// <summary>
    /// Name query string parameter class.
    /// </summary>
    /// <seealso cref="VivialConnect.Http.QueryParams" />
    /// <seealso cref="VivialConnect.Resources.INameQueryParams" />
    public class NameQueryParams : QueryParams, INameQueryParams
    {
        /// <summary>
        /// The Name query string parameter.
        /// </summary>
        /// <value>
        /// Name query string parameter.
        /// </value>
        public string Name { get; set; }
    }
}
