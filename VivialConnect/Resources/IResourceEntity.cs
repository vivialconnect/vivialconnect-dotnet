using Newtonsoft.Json;

namespace VivialConnect.Resources
{
    /// <summary>
    /// Interface to be implemented by any class used to 
    /// deserialize the JSON payload from the API.
    /// </summary>    
    public interface IResourceEntity
    {
        /// <summary>
        /// Indicates if the entity is new.
        /// </summary>
        /// <returns></returns>
        [JsonIgnore]
        bool IsNew { get; }
    }
}
