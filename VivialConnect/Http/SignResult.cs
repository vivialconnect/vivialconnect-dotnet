using System.Collections.Generic;

namespace VivialConnect.Http
{
    /// <summary>
    /// Used to hold the results of the sign method.
    /// </summary>
    internal class SignResult
    {
        /// <summary>
        /// The digest.
        /// </summary>
        /// <value>
        /// Digest.
        /// </value>
        public string Digest { get; set; }

        /// <summary>
        /// The used headers.
        /// </summary>
        /// <value>
        /// Used headers.
        /// </value>
        public List<string> UsedHeaders { get; set; }
    }
}
