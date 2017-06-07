using Newtonsoft.Json;

namespace VivialConnect.Resources.Connector
{
    /// <summary>
    /// Class used to hold properties that will be sent as the body
    /// when submitting update connector requests.
    /// </summary>
    /// <seealso cref="VivialConnect.Resources.Connector.CreateConnector" />
    public class UpdateConnector : CreateConnector
    {
        /// <summary>
        /// The connector ID.
        /// </summary>
        /// <param name="id">Connector ID></param>
        public UpdateConnector(int id)
        {
            Id = id;
        }

        /// <summary>
        /// The connector ID.
        /// </summary>
        /// <value>
        /// Connector ID.
        /// </value>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Indicator that is true if the Connector has more than
        /// 50 associated numbers.
        /// </summary>
        /// <value>
        /// More numbers.
        /// </value>
        [JsonProperty("more_numbers")]
        public bool? MoreNumbers { get; set; }
    }
}
