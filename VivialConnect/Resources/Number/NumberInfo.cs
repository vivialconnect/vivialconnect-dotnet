using System;

using Newtonsoft.Json;

namespace VivialConnect.Resources.Number
{
    /// <summary>
    /// Provides device information for a phone number.
    /// </summary>
    /// <seealso cref="VivialConnect.Resources.ResourceEntity" />
    public class NumberInfo : ResourceEntity
    {
        /// <summary>
        /// Details about the phone carrier providing 
        /// service to the phone number.
        /// </summary>
        /// <value>
        /// Carrier.
        /// </value>
        [JsonProperty("carrier")]
        public Carrier Carrier { get; private set; }

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
        /// Details about the device type used by the phone number.
        /// </summary>
        /// <value>
        /// Device.
        /// </value>
        [JsonProperty("device")]
        public Device Device { get; private set; }

        /// <summary>
        /// The phone number.
        /// </summary>
        /// <value>
        /// Phone number.
        /// </value>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; private set; }
    }
}
