using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivialConnect.Resources.Number
{
    /// <summary>
    /// Numbers associated query string parameters class.
    /// </summary>
    /// <seealso cref="VivialConnect.Resources.NameQueryParams" />
    /// <seealso cref="VivialConnect.Resources.IContainsQueryParams" />
    /// <seealso cref="VivialConnect.Resources.IPagingQueryParams" />
    public class NumbersQueryParams : NameQueryParams, IContainsQueryParams, IPagingQueryParams
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NumbersQueryParams"/> class.
        /// </summary>
        public NumbersQueryParams() { }

        /// <summary>
        /// The Contains query string parameter.
        /// </summary>
        /// <value>
        /// Contains query string parameter.
        /// </value>
        public string Contains { get; set; }

        /// <summary>
        /// The page number.
        /// </summary>
        /// <value>
        /// Page number.
        /// </value>
        public int Page { get; set; }

        /// <summary>
        /// The size of the page.
        /// </summary>
        /// <value>
        /// Size of the page.
        /// </value>
        public int PageSize { get; set; }
    }
}
