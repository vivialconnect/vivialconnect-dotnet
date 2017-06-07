using Newtonsoft.Json;
using VivialConnect.Http;

namespace VivialConnect.Resources.Number
{
    /// <summary>
    /// Lookup query string parameter class.
    /// </summary>
    /// <seealso cref="VivialConnect.Http.QueryParams" />
    public class LookupQueryParams : QueryParams
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="LookupQueryParams"/> class from being created.
        /// </summary>
        private LookupQueryParams() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="LookupQueryParams"/> class.
        /// </summary>
        /// <param name="phoneNumber">Phone number.</param>
        public LookupQueryParams(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// The phone number.
        /// </summary>
        /// <value>
        /// Phone number.
        /// </value>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
    }
}
