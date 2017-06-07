using Newtonsoft.Json;

namespace VivialConnect.Resources.Number
{
    /// <summary>
    /// Details about the phone carrier providing service to the phone number.
    /// </summary>
    public class Carrier
    {
        /// <summary>
        /// The Carrier Capabilities.
        /// </summary>
        /// <value>
        /// Capabilities.
        /// </value>
        [JsonProperty("capabilities")]
        public CarrierCapabilities Capabilities { get; private set; }

        /// <summary>
        /// The country.
        /// </summary>
        /// <value>
        /// Country.
        /// </value>
        [JsonProperty("country")]
        public string Country { get; private set; }

        /// <summary>
        /// The name.
        /// </summary>
        /// <value>
        /// Name.
        /// </value>
        [JsonProperty("name")]
        public string Name { get; private set; }
    }
}
