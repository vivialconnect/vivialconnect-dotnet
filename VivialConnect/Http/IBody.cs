
using Newtonsoft.Json;

namespace VivialConnect.Http
{
    /// <summary>
    /// Interface to be implemented by any class that will serve as the Body to be submitted to the API.
    /// </summary>
    public interface IBody
    {
        /// <summary>
        /// The name to be used as the root node when serializing to JSON.
        /// </summary>
        /// <value>
        /// Root name.
        /// </value>
        [JsonIgnore]
        string RootName { get; }

        /// <summary>
        /// Serializes as JSON.
        /// </summary>
        /// <returns></returns>
        string SerializeAsJson();
    }
}
