using System.Collections.Generic;

using Newtonsoft.Json;

namespace VivialConnect.Http
{
    /// <summary>
    /// Base class used to represent the Body submitted to the API.
    /// </summary>
    /// <seealso cref="VivialConnect.Http.IBody" />
    public abstract class Body : IBody
    {
        /// <summary>
        /// Gets the name to be used as the root node when serializing to JSON.
        /// </summary>
        /// <value>
        /// Root name.
        /// </value>
        public abstract string RootName { get; }

        /// <summary>
        /// Serializes as JSON.
        /// </summary>
        /// <returns></returns>
        public string SerializeAsJson()
        {
            if (string.IsNullOrWhiteSpace(RootName))
            {
                return JsonConvert.SerializeObject(this, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            }
            else
            {
                return JsonConvert.SerializeObject(new Dictionary<string, IBody> { { RootName, this } }, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            }
        }
    }
}
