using Newtonsoft.Json;

namespace VivialConnect.Resources.Number
{
    /// <summary>
    /// Details about the device type used by the phone number.
    /// </summary>
    public class Device
    {
        /// <summary>
        /// The model name of the device.
        /// </summary>
        /// <value>
        /// Model.
        /// </value>
        [JsonProperty("model")]
        public string Model { get; private set; }

        /// <summary>
        /// The error message, if any, when attempting
        /// to retrieve the device details.
        /// </summary>
        /// <value>
        /// Error.
        /// </value>
        [JsonProperty("error")]
        public string Error { get; private set; }
    }
}
