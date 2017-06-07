using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VivialConnect.Converters;
using VivialConnect.Http;

namespace VivialConnect.Resources.Connector
{
    /// <summary>
    /// Resource for managing connectors and their components.
    /// Connectors act as configurable gateways through which
    /// messages can be sent, providing services like
    /// callback configuration and from number pooling.
    /// </summary>
    /// <seealso cref="VivialConnect.Resources.ResourceEntity" />
    public class Connector : ResourceEntity
    {
        private const string EndpointConnectors = "/accounts/{0}/connectors.json";
        private const string EndpointCount = "/accounts/{0}/connectors/count.json";
        private const string EndpointConnectorId = "/accounts/{0}/connectors/{1}.json";
        private const string EndpointConnectorPhoneNumbers = "/accounts/{0}/connectors/{1}/phone_numbers.json";

        /// <summary>
        /// Initializes a new instance of the <see cref="Connector"/> class. 
        /// </summary>
        public Connector()
        {
            AccountId = VcClient.AccountId;
            Active = true;
            Callbacks = new List<ICallback>();
            Numbers = new List<ConnectorNumber>();
        }

        /// <summary>
        /// The unique identifier of the account associated
        /// with the connector.
        /// </summary>
        /// <value>
        /// Account ID.
        /// </value>
        [JsonProperty("account_id")]
        public int AccountId { get; set; }

        /// <summary>
        /// Value indicating whether this <see cref="Resources.Connector"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("active")]
        public bool Active { get; set; }

        /// <summary>
        /// The date created.
        /// </summary>
        /// <value>
        /// Date created.
        /// </value>
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        /// <summary>
        /// The date modified.
        /// </summary>
        /// <value>
        /// Date modified.
        /// </value>
        [JsonProperty("date_modified")]
        public DateTime? DateModified { get; private set; }

        /// <summary>
        /// The connector ID.
        /// </summary>
        /// <value>
        /// Connector ID.
        /// </value>
        [JsonProperty("id")]
        public int? Id { get; private set; }

        /// <summary>
        /// The user defined name of the connector.
        /// </summary>
        /// <value>
        /// Name of the connector.
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
        /// Indicator that is true if the Connector has more than
        /// 50 associated numbers.
        /// </summary>
        /// <value>
        /// More numbers.
        /// </value>
        [JsonProperty("more_numbers")]
        public bool? MoreNumbers { get; private set; }

        /// <summary>
        /// Indicates if the connector is new.
        /// </summary>
        /// <returns></returns>
        public override bool IsNew
        {
            get
            { 
                return this.Id == null ? true : false;
            }
        }

        /// <summary>
        /// Sets the MoreNumbers flag to false.
        /// </summary>
        private void ResetMoreNumbers()
        {
            MoreNumbers = false;
        }

        /// <summary>
        /// Saves the connector.
        /// </summary>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public void Save(IVcRestClient client = null)
        {
            Connector connector = null;

            if (this.IsNew)
            {
                connector = Create(VcClient.AccountId, this.Active, this.Name, this.Callbacks, this.Numbers, client);
            }
            else
            {
                connector = Update(this.AccountId, (int)this.Id, this.Active, this.Name, this.Callbacks, this.Numbers, (bool)this.MoreNumbers, client);
            }

            Mapper.Map(connector, this);
        }

        /// <summary>
        /// Deletes the connector.
        /// </summary>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public bool Delete(IVcRestClient client = null)
        {
            if(this.IsNew)
            {
                return true;
            }
            return Delete(this.AccountId, (int)this.Id, client);
        }

        /// <summary>
        /// Gets the specified connector.
        /// </summary>
        /// <param name="id">Connector ID.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public static Connector FindSingle(int id, IVcRestClient client = null)
        {
            return GetSingle(VcClient.AccountId, id, client);
        }

        /// <summary>
        /// Gets the count of connectors.
        /// </summary>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public static int Count(IVcRestClient client = null)
        {
            return Count(VcClient.AccountId, client);
        }

        /// <summary>
        /// Gets all connectors.
        /// </summary>
        /// <param name="page">Page.</param>
        /// <param name="pageSize">Page size.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public static List<Connector> Find(int page = DefaultPage, int pageSize = DefaultPageSize, IVcRestClient client = null)
        {
            return Get(VcClient.AccountId, page, pageSize, client);
        }

        /// <summary>
        /// Deletes the specified connector.
        /// </summary>
        /// <param name="id">Connector ID.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public static bool Delete(int id, IVcRestClient client = null)
        {
            return Delete(VcClient.AccountId, id, client);
        }

        /// <summary>
        /// Populates all phone numbers for the connector.
        /// </summary>
        /// <param name="connector">Connector.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static Connector PopulatePhoneNumbers(Connector connector, IVcRestClient client = null)
        {
            if((bool)connector.MoreNumbers)
            {
                connector.Numbers = GetPhoneNumbers(connector.AccountId, (int)connector.Id, client);
                connector.ResetMoreNumbers();
            }

            return connector;
        }

        /// <summary>
        /// Creates connector based on parameter values.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="name">Name.</param>
        /// <param name="callbacks">Callbacks.</param>
        /// <param name="numbers">Phone Number.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static Connector Create(int accountId, bool active, string name, List<ICallback> callbacks, List<ConnectorNumber> numbers, IVcRestClient client = null)
        {
            CreateConnector createConnector = new CreateConnector(name)
            {
                Active = active,
                Callbacks = callbacks,
                Numbers = numbers
            };

            return Create(accountId, createConnector, client);
        }

        /// <summary>
        /// Creates a connector based on CreateConnector object.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="createConnector">CreateConnector</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static Connector Create(int accountId, CreateConnector createConnector, IVcRestClient client = null)
        {
            Connector connector = Create<Connector>(BuildCreateUrl(accountId), createConnector, new JsonConverter[] { new CallbackJsonConverter() }, client);
            PopulatePhoneNumbers(connector, client);

            return connector;
        }

        /// <summary>
        /// Updates connector based on parameter values.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="id">Connector ID.</param>
        /// <param name="active">Active.</param>
        /// <param name="name">Name.</param>
        /// <param name="callbacks">Callbacks.</param>
        /// <param name="numbers">Phone Numbers.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static Connector Update(int accountId, int id, bool active, string name, List<ICallback> callbacks, List<ConnectorNumber> numbers, bool moreNumbers, IVcRestClient client = null)
        {
            UpdateConnector updateConnector = new UpdateConnector(id)
            {
                Active = active,
                Name = name,
                Callbacks = callbacks,
                Numbers = numbers,
                MoreNumbers = moreNumbers
            };

            return Update(accountId, updateConnector, client);
        }

        /// <summary>
        /// Updates connector based on "UpdateConnector" object.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="updateConnector">Update Connector.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static Connector Update(int accountId, UpdateConnector updateConnector, IVcRestClient client = null)
        {
            Connector connector = Update<Connector>(BuildUpdateUrl(accountId, updateConnector.Id), updateConnector, new JsonConverter[] { new CallbackJsonConverter() }, client);
            PopulatePhoneNumbers(connector, client);

            return connector;
        }

        /// <summary>
        /// Deletes the connector.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="id">Connector ID.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static bool Delete(int accountId, int id, IVcRestClient client = null)
        {
            return Delete(BuildDeleteUrl(accountId, id), client);
        }

        /// <summary>
        /// Count of connectors for the specified account.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static int Count(int accountId, IVcRestClient client = null)
        {
            return Count(BuildCountUrl(accountId), client: client);
        }

        /// <summary>
        /// Gets connectors for the specified account.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="page">Page.</param>
        /// <param name="pageSize">Page size.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static List<Connector> Get(int accountId, int page = DefaultPage, int pageSize = DefaultPageSize, IVcRestClient client = null)
        {
            PagingQueryParams queryParams = new PagingQueryParams(page, pageSize);
            List<Connector> connectors = Get<Connector>(BuildGetUrl(accountId), queryParams, new JsonConverter[] { new CallbackJsonConverter() }, client);
            foreach (Connector connector in connectors.Where(c => c.MoreNumbers == true))
            {
                PopulatePhoneNumbers(connector, client);
            }

            return connectors;
        }

        /// <summary>
        /// Gets a connector by ID.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="id">Connector ID.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static Connector GetSingle(int accountId, int id, IVcRestClient client =  null)
        {
            Connector connector = GetSingle<Connector>(BuildGetSingleUrl(accountId, id), jsonConverters: new JsonConverter[] { new CallbackJsonConverter() }, client: client);
            PopulatePhoneNumbers(connector, client);

            return connector;
        }

        /// <summary>
        /// Gets all the phone numbers for
        /// the specified connector.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="connectorId">Connector ID.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static List<ConnectorNumber> GetPhoneNumbers(int accountId, int connectorId, IVcRestClient client = null)
        {
            string content = GetRawContent(BuildGetPhoneNumbersUrl(accountId, connectorId), client: client);
            JObject json = JObject.Parse(content);

            return JsonConvert.DeserializeObject<List<ConnectorNumber>>(json["connector"]["phone_numbers"].ToString());
        }        

        /// <summary>
        /// Builds the count URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <returns></returns>
        private static string BuildCountUrl(int accountId)
        {
            return string.Format(EndpointCount, accountId);
        }

        /// <summary>
        /// Builds the get URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <returns></returns>
        private static string BuildGetUrl(int accountId)
        {
            return string.Format(EndpointConnectors, accountId);
        }

        /// <summary>
        /// Builds the get single URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="id">Connector ID.</param>
        /// <returns></returns>
        private static string BuildGetSingleUrl(int accountId, int id)
        {
            return string.Format(EndpointConnectorId, accountId, id);
        }

        /// <summary>
        /// Builds the create URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <returns></returns>
        private static string BuildCreateUrl(int accountId)
        {
            return string.Format(EndpointConnectors, accountId);
        }

        /// <summary>
        /// Builds update URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="id">Connector ID.</param>
        /// <returns></returns>
        private static string BuildUpdateUrl(int accountId, int id)
        {
            return string.Format(EndpointConnectorId, accountId, id);
        }

        /// <summary>
        /// Builds delete URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="id">Connector ID.</param>
        /// <returns></returns>
        private static string BuildDeleteUrl(int accountId, int id)
        {
            return string.Format(EndpointConnectorId, accountId, id);
        }

        /// <summary>
        /// Builds get phone numbers URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="connectorId">Connector ID.</param>
        /// <returns></returns>
        private static string BuildGetPhoneNumbersUrl(int accountId, int connectorId)
        {
            return string.Format(EndpointConnectorPhoneNumbers, accountId, connectorId);
        }
    }
}
