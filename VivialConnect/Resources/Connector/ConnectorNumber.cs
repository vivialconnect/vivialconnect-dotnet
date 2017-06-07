using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace VivialConnect.Resources.Connector
{
    /// <summary>
    /// Details about the phone number associated to the connector.
    /// </summary>
    public class ConnectorNumber : ResourceEntity
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="ConnectorNumber"/> class from being created.
        /// </summary>
        private ConnectorNumber() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectorNumber"/> class.
        /// </summary>
        /// <param name="number">Phone number.</param>
        public ConnectorNumber(string number)
        {
            Number = number;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectorNumber"/> class.
        /// </summary>
        /// <param name="id">Phone number ID.</param>
        public ConnectorNumber(int id)
        {
            Id = id;
        }

        /// <summary>
        /// Indicates if phone number is new.
        /// </summary>
        public override bool IsNew
        {
            get
            {
                return Id == null ? true : false;
            }
        }

        /// <summary>
        /// The phone number.
        /// </summary>
        /// <value>
        /// Phone number.
        /// </value>
        [JsonProperty("phone_number")]
        public string Number { get; set; }

        /// <summary>
        /// The phone number ID.
        /// </summary>
        /// <value>
        /// Phone number ID.
        /// </value>
        [JsonProperty("phone_number_id")]
        public int? Id { get; private set; }
    }
}
