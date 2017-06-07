using Newtonsoft.Json;
using VivialConnect.Http;

namespace VivialConnect.Resources.Account
{
    /// <summary>
    /// Class used to hold properties that will be sent as the body
    /// when submitting update account requests.
    /// </summary>
    /// <seealso cref="VivialConnect.Http.Body" />
    public class UpdateAccount : Body
    {
        /// <summary>
        /// The account ID.
        /// </summary>
        /// <value>
        /// Account ID.
        /// </value>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// The name of the company.
        /// </summary>
        /// <value>
        /// Name of the company.
        /// </value>
        [JsonProperty("company_name")]
        public string CompanyName { get; set; }

        /// <summary>
        /// The name to be used as the root node 
        /// when serializing to JSON.
        /// </summary>
        /// <value>
        /// Root name.
        /// </value>
        public override string RootName
        {
            get { return "account"; }
        }
    }
}
