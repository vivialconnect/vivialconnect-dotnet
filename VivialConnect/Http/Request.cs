using System.Collections.Generic;

namespace VivialConnect.Http
{
    /// <summary>
    /// VivialConnect request class.
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Request"/> class.
        /// </summary>
        /// <param name="method">HTTP method.</param>
        /// <param name="url">Request URL.</param>
        public Request(string method, string url)
        {
            Method = method;
            Url = url;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Request"/> class.
        /// </summary>
        /// <param name="method">HTTP method.</param>
        /// <param name="url">Request URL.</param>
        /// <param name="queryParams">Query string parameters.</param>
        public Request(string method, string url, IQueryParams queryParams)
        {
            Method = method;
            Url = url;
            QueryParams = queryParams;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Request"/> class.
        /// </summary>
        /// <param name="method">HTTP method.</param>
        /// <param name="url">Request URL.</param>
        /// <param name="body">HTTP body.</param>
        public Request(string method, string url, IBody body)
        {
            Method = method;
            Url = url;
            Body = body;
        }

        /// <summary>
        /// The HTTP method.
        /// </summary>
        /// <value>
        /// Method.
        /// </value>
        public string Method { get; }

        /// <summary>
        /// The request URL.
        /// </summary>
        /// <value>
        /// URL.
        /// </value>
        public string Url { get; }

        /// <summary>
        /// The query string parameters.
        /// </summary>
        /// <value>
        /// Query string parameters.
        /// </value>
        public IQueryParams QueryParams { get; set; }

        /// <summary>
        /// The HTTP body.
        /// </summary>
        /// <value>
        /// HTTP body.
        /// </value>
        public IBody Body { get; set; }

        /// <summary>
        /// A value indicating whether this instance has a HTTP body.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has a HTTP body; otherwise, <c>false</c>.
        /// </value>
        public bool HasBody
        {
            get
            {
                return Body != null;
            }
        }

        /// <summary>
        /// The HTTP body as JSON.
        /// </summary>
        /// <returns></returns>
        public string GetBodyAsJson()
        {
            return Body != null ? Body.SerializeAsJson() : string.Empty;
        }

        /// <summary>
        /// The query string parameters as a list.
        /// </summary>
        /// <returns></returns>
        public List<KeyValuePair<string, string>> GetQueryParamsList()
        {
            return QueryParams != null ? QueryParams.GetAsList() : new List<KeyValuePair<string, string>>();
        }
    }
}
