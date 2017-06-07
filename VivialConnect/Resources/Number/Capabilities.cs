using Newtonsoft.Json;

namespace VivialConnect.Resources.Number
{
    /// <summary>
    /// Class used to store capabilities flags.
    /// </summary>
    public class Capabilities
    {
        /// <summary>
        /// Value indicating whether this <see cref="Capabilities"/> is MMS.
        /// </summary>
        /// <value>
        ///   <c>true</c> if MMS; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("mms")]
        public bool MMS { get; set; }

        /// <summary>
        /// Value indicating whether this <see cref="Capabilities"/> is SMS.
        /// </summary>
        /// <value>
        ///   <c>true</c> if SMS; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("sms")]
        public bool SMS { get; set; }

        /// <summary>
        /// Value indicating whether this <see cref="Capabilities"/> is voice.
        /// </summary>
        /// <value>
        ///   <c>true</c> if voice; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("voice")]
        public bool Voice { get; set; }
    }
}
