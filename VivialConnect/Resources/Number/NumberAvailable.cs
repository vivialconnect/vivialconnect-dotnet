using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VivialConnect.Http;

namespace VivialConnect.Resources.Number
{
    /// <summary>
    /// Details about an available phone number.
    /// </summary>
    /// <seealso cref="VivialConnect.Resources.ResourceEntity" />
    public class NumberAvailable : ResourceEntity
    {
        /// <summary>
        /// The city where the available phone number is located.
        /// </summary>
        /// <value>
        /// City.
        /// </value>
        [JsonProperty("city")]
        public string City { get; private set; }

        /// <summary>
        /// The local address and transport area (LATA) 
        /// where the available phone number is located.
        /// </summary>
        /// <value>
        /// LATA.
        /// </value>
        [JsonProperty("lata")]
        public string Lata { get; private set; }

        /// <summary>
        /// The phone number as it is displayed to users.
        /// </summary>
        /// <value>
        /// Name.
        /// </value>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        /// The available phone number.
        /// </summary>
        /// <value>
        /// Available phone number.
        /// </value>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; private set; }

        /// <summary>
        /// The type of available phone number.
        /// </summary>
        /// <value>
        /// Type of available phone number.
        /// </value>
        [JsonProperty("phone_number_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PhoneNumberTypeEnum PhoneNumberType { get; private set; }

        /// <summary>
        /// The LATA rate center where the available phone number is located.
        /// </summary>
        /// <value>
        /// Rate center.
        /// </value>
        [JsonProperty("rate_center")]
        public string RateCenter { get; private set; }

        /// <summary>
        /// The two-letter US state abbreviation where the 
        /// available phone number is located.
        /// </summary>
        /// <value>
        /// Region.
        /// </value>
        [JsonProperty("region")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RegionEnum Region { get; private set; }

        /// <summary>
        /// Purchases phone number based on this available number.
        /// </summary>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public Number Buy(IVcRestClient client = null)
        {
            return Number.Buy(this, client);
        }
    }
}
