using System;

using Newtonsoft.Json;

namespace VivialConnect.Resources.User
{
    /// <summary>
    /// Role details for user.
    /// </summary>
    public class Role
    {
        /// <summary>
        /// A value indicating whether this <see cref="Role"/> is active.
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
        /// The description.
        /// </summary>
        /// <value>
        /// Description.
        /// </value>
        [JsonProperty("description")]
        public string Description { get; private set; }

        /// <summary>
        /// The role ID.
        /// </summary>
        /// <value>
        /// Role ID.
        /// </value>
        [JsonProperty("id")]
        public int Id { get; private set; }

        /// <summary>
        /// The role name.
        /// </summary>
        /// <value>
        /// Role name.
        /// </value>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        /// The role type.
        /// </summary>
        /// <value>
        /// Role type.
        /// </value>
        [JsonProperty("role_type")]
        public string RoleType { get; private set; }
    }
}
