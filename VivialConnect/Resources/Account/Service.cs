using System;

using Newtonsoft.Json;

namespace VivialConnect.Resources.Account
{
    /// <summary>
    /// Service associated to the account.
    /// </summary>
    public class Service
    {
        /// <summary>
        /// The service ID.
        /// </summary>
        /// <value>
        /// Service ID.
        /// </value>
        [JsonProperty("id")]
        public int Id { get; private set; }

        /// <summary>
        /// Value indicating whether this <see cref="Service"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("active")]
        public bool Active { get; private set; }

        /// <summary>
        /// The date created.
        /// </summary>
        /// <value>
        /// Date created.
        /// </value>
        [JsonProperty("date_created")]
        public DateTime DateCreated { get; private set; }

        /// <summary>
        /// The date modified.
        /// </summary>
        /// <value>
        /// Date modified.
        /// </value>
        [JsonProperty("date_modified")]
        public DateTime DateModified { get; private set; }

        /// <summary>
        /// The service description.
        /// </summary>
        /// <value>
        /// Service description.
        /// </value>
        [JsonProperty("description")]
        public string Description { get; private set; }

        /// <summary>
        /// The service name.
        /// </summary>
        /// <value>
        /// Service name.
        /// </value>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        /// The type of the service.
        /// </summary>
        /// <value>
        /// Type of service.
        /// </value>
        [JsonProperty("service_type")]
        public string ServiceType { get; private set; }
    }
}
