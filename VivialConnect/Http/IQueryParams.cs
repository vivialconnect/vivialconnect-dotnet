using System.Collections.Generic;

namespace VivialConnect.Http
{
    /// <summary>
    /// Interface to be implemented by any class that will serve as the Query Parameters to be submitted to the API.
    /// </summary>
    public interface IQueryParams
    {
        /// <summary>
        /// The class properties as a list of key/value pairs.
        /// </summary>
        /// <returns></returns>
        List<KeyValuePair<string, string>>  GetAsList();
    }
}
