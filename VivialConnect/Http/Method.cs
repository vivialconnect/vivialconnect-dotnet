using System;

namespace VivialConnect.Http
{
    /// <summary>
    /// Class used to hold the supported HTTP methods.
    /// </summary>
    public class Method
    {
        public const string Get = "GET";
        public const string Post = "POST";
        public const string Put = "PUT";
        public const string Delete = "DELETE";

        /// <summary>
        /// Determines whether [is POST or PUT] based on [the specified method].
        /// </summary>
        /// <param name="method">HTTP method.</param>
        /// <returns>
        ///   <c>true</c> if [is POST or PUT] based on [the specified method]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsPostOrPut(string method)
        {
            if (method.Equals(Post, StringComparison.OrdinalIgnoreCase) ||
                method.Equals(Put, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }
    }
}
