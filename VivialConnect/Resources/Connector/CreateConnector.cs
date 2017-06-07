using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using VivialConnect.Http;

namespace VivialConnect.Resources.Connector
{
    /// <summary>
    /// Class used to hold properties that will be sent as the body
    /// when submitting create connector requests.
    /// </summary>
    /// <seealso cref="VivialConnect.Http.Body" />
    public class CreateConnector : Body
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateConnector"/> class.
        /// </summary>
        public CreateConnector() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateConnector"/> class.
        /// </summary>
        /// <param name="name">Connector name.</param>
        public CreateConnector(string name)
        {
            Name = name;
            Active = true;
            Callbacks = new List<ICallback>();
            Numbers = new List<ConnectorNumber>();
        }

        /// <summary>
        /// Value indicating whether this <see cref="Resources.UpdateConnector"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("active")]
        public bool Active { get; set; }

        /// <summary>
        /// The name of the connector.
        /// </summary>
        /// <value>
        /// Connector name.
        /// </value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// List of callbacks representing the callback
        /// configurations for the connector.
        /// </summary>
        /// <value>
        /// Callbacks.
        /// </value>
        [JsonProperty("callbacks")]
        public List<ICallback> Callbacks { get; set; }        

        /// <summary>
        /// List of phone numbers associated to the
        /// connector.
        /// </summary>
        /// <value>
        /// Phone numbers.
        /// </value>
        [JsonProperty("phone_numbers")]
        public List<ConnectorNumber> Numbers { get; set; }

        /// <summary>
        /// The name to be used as the root node when 
        /// serializing to JSON.
        /// </summary>
        /// <value>
        /// Root name.
        /// </value>
        public override string RootName
        {
            get { return "connector"; }
        }
    }
}
