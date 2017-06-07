using Newtonsoft.Json;
using VivialConnect.Http;

namespace VivialConnect.Resources.Number
{
    /// <summary>
    /// Numbers available query string parameters class.
    /// </summary>
    /// <seealso cref="VivialConnect.Http.QueryParams" />
    public class NumbersAvailableQueryParams : QueryParams
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="NumbersAvailableQueryParams"/> class from being created.
        /// </summary>
        private NumbersAvailableQueryParams() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NumbersAvailableQueryParams"/> class.
        /// </summary>
        /// <param name="areaCode">Area code.</param>
        public NumbersAvailableQueryParams(int areaCode)
        {
            AreaCode = areaCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NumbersAvailableQueryParams"/> class.
        /// </summary>
        /// <param name="inPostalCode">In postal code.</param>
        public NumbersAvailableQueryParams(string inPostalCode)
        {
            InPostalCode = InPostalCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NumbersAvailableQueryParams"/> class.
        /// </summary>
        /// <param name="inRegion">In region.</param>
        public NumbersAvailableQueryParams(RegionEnum inRegion)
        {
            InRegion = inRegion;
        }

        /// <summary>
        /// Number of results to return per page.
        /// </summary>
        /// <value>
        /// Limit.
        /// </value>
        [JsonProperty("limit")]
        public int? Limit { get; set; }

        /// <summary>
        /// Filters the results to include only phone 
        /// numbers that match a number pattern you 
        /// specify. The pattern can include letters, 
        /// digits, and the following wildcard characters.
        /// </summary>
        /// <value>
        /// Contains.
        /// </value>
        [JsonProperty("contains")]
        public string Contains { get; set; }

        /// <summary>
        /// Filters the results to include only phone 
        /// numbers in a specified 5-digit postal code.
        /// </summary>
        /// <value>
        /// In postal code.
        /// </value>
        [JsonProperty("in_postal_code")]
        public string InPostalCode { get; set; }

        /// <summary>
        /// Filters the results to include only phone 
        /// numbers by US area code.
        /// </summary>
        /// <value>
        /// Area code.
        /// </value>
        [JsonProperty("area_code")]
        public int? AreaCode { get; set; }

        /// <summary>
        /// Filters the results to include only phone 
        /// numbers in a specified city.
        /// </summary>
        /// <value>
        /// In city.
        /// </value>
        [JsonProperty("in_city")]
        public string InCity { get; set; }

        /// <summary>
        /// Filters the results include only phone numbers 
        /// in a specified 2-letter region (US state).
        /// </summary>
        /// <value>
        /// In region.
        /// </value>
        [JsonProperty("in_region")]
        public RegionEnum? InRegion { get; set; }

        /// <summary>
        /// Filters the results to include only phone 
        /// numbers that match the first three or more 
        /// digits you specify to immediately follow 
        /// the area code. To use this parameter, you 
        /// must also specify an area_code.
        /// </summary>
        /// <value>
        /// Local number.
        /// </value>
        [JsonProperty("local_number")]
        public string LocalNumber { get; set; }
    }
}
