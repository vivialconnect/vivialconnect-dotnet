using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VivialConnect.Http;
using VivialConnect.Mappings;

namespace VivialConnect.Resources.Number
{
    /// <summary>
    /// Resource for managing phone numbers and querying information
    /// about the device type and carrier that is associated with
    /// a specific phone number.
    /// </summary>
    /// <seealso cref="VivialConnect.Resources.ResourceEntity" />
    public class Number : ResourceEntity
    {
        private const string EndpointNumbersAvailable = "/accounts/{0}/numbers/available/US/local.json";
        private const string EndpointNumbersLookup = "/accounts/{0}/numbers/lookup.json";
        private const string EndpointNumbers = "/accounts/{0}/numbers.json";
        private const string EndpointCount = "/accounts/{0}/numbers/count.json";
        private const string EndpointNumberId = "accounts/{0}/numbers/{1}.json";
        private const string EndpointNumbersLocal = "/accounts/{0}/numbers/local.json";
        private const string EndpointNumbersLocalCount = "/accounts/{0}/numbers/local/count.json";
        private const string EndpointNumberLocalId = "/accounts/{0}/numbers/local/{1}.json";

        /// <summary>
        /// Prevents a default instance of the <see cref="Number"/> class.
        /// </summary>
        private Number() { }

        /// <summary>
        /// The unique identifier of the account or subaccount 
        /// associated with the phone number.
        /// </summary>
        /// <value>
        /// Account ID.
        /// </value>
        [JsonProperty("account_id")]
        public int AccountId { get; private set; }

        /// <summary>
        /// Value indicating whether this <see cref="Resources.Number.Number"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("active")]
        public bool Active { get; private set; }

        /// <summary>
        /// The Address requirements.
        /// </summary>
        /// <value>
        /// Address requirements.
        /// </value>
        [JsonProperty("address_requirements")]
        public string AddressRequirements { get; private set; }

        /// <summary>
        /// Set of boolean flags indicating the capabilities 
        /// supported by the associated phone number.
        /// </summary>
        /// <value>
        /// Capabilities.
        /// </value>
        [JsonProperty("capabilities")]
        public Capabilities Capabilities { get; private set; }

        /// <summary>
        /// The city where the available phone number is located.
        /// </summary>
        /// <value>
        /// City.
        /// </value>
        [JsonProperty("city")]
        public string City { get; private set; }

        /// <summary>
        /// The date created.
        /// </summary>
        /// <value>
        /// Date created.
        /// </value>
        [JsonProperty("date_created")]
        public DateTime DateCreated { get; private set; }

        /// <summary>
        /// The date modified.
        /// </summary>
        /// <value>
        /// Date modified.
        /// </value>
        [JsonProperty("date_modified")]
        public DateTime DateModified { get; private set; }

        /// <summary>
        /// The unique identifier of the phone number object.
        /// </summary>
        /// <value>
        /// ID.
        /// </value>
        [JsonProperty("id")]
        public int Id { get; private set; }

        /// <summary>
        /// The HTTP method used for SMS Fallback URL requests.
        /// </summary>
        /// <value>
        /// Incoming text fallback method.
        /// </value>
        [JsonProperty("incoming_text_fallback_method")]
        public string IncomingTextFallbackMethod { get; set; }

        /// <summary>
        /// The URL for receiving SMS messages if SMS URL 
        /// fails. Only valid if you provide a value for 
        /// the SMS URL parameter.
        /// </summary>
        /// <value>
        /// Incoming text fallback URL.
        /// </value>
        [JsonProperty("incoming_text_fallback_url")]
        public string IncomingTextFallbackUrl { get; set; }

        /// <summary>
        /// The HTTP method used for the SMS URL requests.
        /// </summary>
        /// <value>
        /// Incoming text method.
        /// </value>
        [JsonProperty("incoming_text_method")]
        public string IncomingTextMethod { get; set; }

        /// <summary>
        /// The URL for receiving SMS messages to the 
        /// associated phone number.
        /// </summary>
        /// <value>
        /// Incoming Text URL.
        /// </value>
        [JsonProperty("incoming_text_url")]
        public string IncomingTextUrl { get; set; }

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
        public string Name { get; set; }

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
        /// The URL to receive message status callback 
        /// requests for messages sent via the API using 
        /// this associated phone number.
        /// </summary>
        /// <value>
        /// Status Text URL.
        /// </value>
        [JsonProperty("status_text_url")]
        public string StatusTextUrl { get; set; }

        /// <summary>
        /// The number to which voice calls will be forwarded.
        /// </summary>
        /// <value>
        /// Voice forwarding number.
        /// </value>
        [JsonProperty("voice_forwarding_number")]
        public string VoiceForwardingNumber { get; set; }

        /// <summary>
        /// Indicates if number is new.
        /// Defaults to false.
        /// </summary>
        public override bool IsNew
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Saves updates to the phone number.
        /// </summary>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public void Save(IVcRestClient client = null)
        {
            Number number = null;

            UpdateNumber updateNumber = new UpdateNumber(this.Id)
            {
                Name = this.Name,
                StatusTextUrl = this.StatusTextUrl,
                IncomingTextUrl = this.IncomingTextUrl,
                IncomingTextMethod = this.IncomingTextMethod,
                IncomingTextFallbackUrl = this.IncomingTextFallbackUrl,
                IncomingTextFallbackMethod = this.IncomingTextFallbackMethod,
                VoiceForwardingNumber = this.VoiceForwardingNumber
            };

            if(this.PhoneNumberType == PhoneNumberTypeEnum.Local)
            {
                number = UpdateLocal(this.AccountId, updateNumber, client);
            }
            else
            {
                number = Update(this.AccountId, updateNumber, client);
            }

            ResourceConfiguration.GetMapper().Map(number, this);
        }

        /// <summary>
        /// Gets information about the device type
        /// and carrier that is associated with
        /// this phone number.
        /// </summary>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public NumberInfo Lookup(IVcRestClient client = null)
        {
            return Lookup(this.AccountId, this.PhoneNumber, client);
        }


        /// <summary>
        /// Deletes the phone number.
        /// </summary>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public bool Delete(IVcRestClient client = null)
        {
            if(this.PhoneNumberType == PhoneNumberTypeEnum.Local)
            {
                return DeleteLocal(this.AccountId, this.Id, client);
            }

            return Delete(this.AccountId, this.Id, client);
        }

        /// <summary>
        /// Purchases a new phone number based on available number.
        /// </summary>
        /// <param name="numberAvailable">NumberAvailable.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public static Number Buy(NumberAvailable numberAvailable, IVcRestClient client = null)
        {
            return Buy(numberAvailable.PhoneNumberType, numberAvailable.PhoneNumber, client: client);
        }

        /// <summary>
        /// Purchases a new phone number.
        /// </summary>
        /// <param name="phoneNumberType">Type of phone number.</param>
        /// <param name="phoneNumber">Phone number.</param>
        /// <param name="areaCode">Area code.</param>
        /// <param name="messageStatusCallback">Message status callback.</param>
        /// <param name="name">Name.</param>
        /// <param name="smsConfigurationId">SMS configuration ID.</param>
        /// <param name="smsFallbackMethod">SMS fallback method.</param>
        /// <param name="smsFallbackUrl">SMS fallback URL.</param>
        /// <param name="smsMethod">SMS method.</param>
        /// <param name="smsUrl">SMS URL.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public static Number Buy(PhoneNumberTypeEnum phoneNumberType,
                            string phoneNumber = null,
                            int? areaCode = null,
                            string name = null,
                            int? connectorId = null,
                            string statusTextUrl = null,
                            string incomingTextUrl = null,
                            string incomingTextMethod = null,
                            string incomingTextFallbackUrl = null,
                            string incomingTextFallbackMethod = null,
                            IVcRestClient client = null)
        {
            if(phoneNumberType == PhoneNumberTypeEnum.Local)
            {
                CreateNumberLocal createNumberLocal = new CreateNumberLocal(phoneNumber)
                {
                    AreaCode = areaCode,
                    Name = name,
                    ConnectorId = connectorId,
                    StatusTextUrl = statusTextUrl,
                    IncomingTextUrl = incomingTextUrl,
                    IncomingTextMethod = incomingTextMethod,
                    IncomingTextFallbackUrl = incomingTextFallbackUrl,
                    IncomingTextFallbackMethod = incomingTextFallbackMethod
                };

                return CreateLocal(VcClient.AccountId, createNumberLocal, client);
            }

            CreateNumber createNumber = new CreateNumber(phoneNumber, phoneNumberType)
            {
                AreaCode = areaCode,
                Name = name,
                ConnectorId = connectorId,
                StatusTextUrl = statusTextUrl,
                IncomingTextUrl = incomingTextUrl,
                IncomingTextMethod = incomingTextMethod,
                IncomingTextFallbackUrl = incomingTextFallbackUrl,
                IncomingTextFallbackMethod = incomingTextFallbackMethod
            };

            return Create(VcClient.AccountId, createNumber, client);
        }

        /// <summary>
        /// Deletes the specified phone number.
        /// </summary>
        /// <param name="id">Phone number ID.</param>
        /// <param name="phoneNumberType">Phone number type.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public static bool Delete(int id, PhoneNumberTypeEnum phoneNumberType, IVcRestClient client = null)
        {
            if(phoneNumberType == PhoneNumberTypeEnum.Local)
            {
                return DeleteLocal(VcClient.AccountId, id);
            }

            return Delete(VcClient.AccountId, id, client);
        }

        /// <summary>
        /// Gets the specified phone number.
        /// </summary>
        /// <param name="id">ID.</param>
        /// <param name="local">Restrict to local numbers only.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public static Number FindSingle(int id, bool local = false, IVcRestClient client = null)
        {
            if(local)
            {
                return GetSingleLocal(VcClient.AccountId, id, client);
            }

            return GetSingle(VcClient.AccountId, id, client);
        }

        /// <summary>
        /// Gets count of phone numbers.
        /// </summary>
        /// <param name="name">Phone name. Ignored when "local" is set to true.</param>
        /// <param name="contains">Contains. Ignored when "local" is set to true.</param>
        /// <param name="local">Restrict to local numbers only.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public static int Count(string name = null, string contains = null, bool local = false, IVcRestClient client = null)
        {
            if(local)
            {
                return CountLocal(VcClient.AccountId, client);
            }

            return Count(VcClient.AccountId, name, contains, client);
        }

        /// <summary>
        /// Gets phone numbers. You can filter by name and
        /// phone numbers that match specified contains pattern.
        /// Name and Contains filters are ignored for local numbers.
        /// </summary>
        /// <param name="name">Phone name. Ignored when "local" is set to true.</param>
        /// <param name="contains">Contains. Ignored when "local" is set to true.</param>
        /// <param name="local">Restrict to local numbers only.</param>
        /// <param name="page">Page.</param>
        /// <param name="pageSize">Page size.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public static List<Number> Find(string name = null, 
                                        string contains = null, 
                                        bool local = false, 
                                        int page = DefaultPage, 
                                        int pageSize = DefaultPageSize, 
                                        IVcRestClient client = null)
        {
            if(local)
            {
                return GetLocal(VcClient.AccountId, page, pageSize, client);
            }

            return Get(VcClient.AccountId, name, contains, page, pageSize, client);
        }

        /// <summary>
        /// Gets available phone numbers.
        /// </summary>
        /// <param name="areaCode">Area code.</param>
        /// <param name="inPostalCode">In postal code.</param>
        /// <param name="inRegion">In region.</param>
        /// <param name="contains">Contains.</param>
        /// <param name="localNumber">Local number.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public static List<NumberAvailable> FindAvailable(string areaCode = null, 
                                                        string inPostalCode = null, 
                                                        RegionEnum? inRegion = null, 
                                                        string contains = null, 
                                                        string localNumber = null, 
                                                        int limit = DefaultPageSize,
                                                        IVcRestClient client = null)
        {
            NumbersAvailableQueryParams queryParams = new NumbersAvailableQueryParams(areaCode)
            {
                InPostalCode = inPostalCode,
                InRegion = inRegion,
                Contains = contains,
                LocalNumber = localNumber,
                Limit = limit
            };

            return GetAvailable(VcClient.AccountId, queryParams, client);
        }

        /// <summary>
        /// Gets information about the device type
        /// and carrier that is associated with
        /// the specified phone number.
        /// </summary>
        /// <param name="phoneNumber">Phone number.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public static NumberInfo Lookup(string phoneNumber, IVcRestClient client = null)
        {
            return Lookup(VcClient.AccountId, phoneNumber, client);
        }

        /// <summary>
        /// Gets available phone numbers.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="queryParams">Query parameters.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static List<NumberAvailable> GetAvailable(int accountId, NumbersAvailableQueryParams queryParams, IVcRestClient client = null)
        {
            return Get<NumberAvailable>(BuildGetAvailableUrl(accountId), queryParams, client: client);
        }

        /// <summary>
        /// Gets information about the device type
        /// and carrier that is associated with
        /// the specified phone number.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="phoneNumber">Phone number.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static NumberInfo Lookup(int accountId, string phoneNumber, IVcRestClient client = null)
        {
            LookupQueryParams queryParams = new LookupQueryParams(phoneNumber);

            return GetSingle<NumberInfo>(BuildLookupUrl(accountId), queryParams, client: client);
        }

        /// <summary>
        /// Gets the specified phone number.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="id">Phone number ID.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static Number GetSingle(int accountId, int id, IVcRestClient client = null)
        {
            return GetSingle<Number>(BuildGetSingleUrl(accountId, id), client: client);
        }

        /// <summary>
        /// Gets the specified local phone number.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="id">Phone number ID.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static Number GetSingleLocal(int accountId, int id, IVcRestClient client = null)
        {
            return GetSingle<Number>(BuildGetSingleLocalUrl(accountId, id), client: client);
        }

        /// <summary>
        /// Updates phone number.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="updateNumber">UpdateNumber.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static Number Update(int accountId, UpdateNumber updateNumber, IVcRestClient client = null)
        {
            return Update<Number>(BuildUpdateUrl(accountId, updateNumber.Id), updateNumber, client: client);
        }

        /// <summary>
        /// Updates local phone number.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="updateNumber">UpdateNumber.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static Number UpdateLocal(int accountId, UpdateNumber updateNumber, IVcRestClient client = null)
        {
            return Update<Number>(BuildUpdateLocalUrl(accountId, updateNumber.Id), updateNumber, client: client);
        }

        /// <summary>
        /// Gets count of phone numbers for specified account.
        /// You can filter by name and phone numbers that 
        /// match specified contains pattern.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="name">Name.</param>
        /// <param name="contains">Contains.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static int Count(int accountId, string name = null, string contains = null, IVcRestClient client = null)
        {
            CountQueryParams queryParams = new CountQueryParams() { Name = name, Contains = contains };

            return Count(BuildCountUrl(accountId), queryParams, client);
        }

        /// <summary>
        /// Gets count of local phone numbers for specified
        /// account.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static int CountLocal(int accountId, IVcRestClient client = null)
        {
            return Count(BuildCountLocalUrl(accountId), client: client);
        }

        /// <summary>
        /// Gets phone numbers associated to the 
        /// specified account. You can filter by name and
        /// phone numbers that match specified contains
        /// pattern.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="name">Name.</param>
        /// <param name="contains">Contains.</param>
        /// <param name="page">Page.</param>
        /// <param name="pageSize">Page Size.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static List<Number> Get(int accountId, string name = null, string contains = null, int page = DefaultPage, int pageSize = DefaultPageSize, IVcRestClient client = null)
        {
            NumbersQueryParams queryParams = new NumbersQueryParams() { Name = name, Contains = contains, Page = page, PageSize = pageSize };

            return Get<Number>(BuildGetUrl(accountId), queryParams, client: client);
        }

        /// <summary>
        /// Gets local phone numbers associated to 
        /// the specified account.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="page">Page.</param>
        /// <param name="pageSize">Page Size.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static List<Number> GetLocal(int accountId, int page = DefaultPage, int pageSize = DefaultPageSize, IVcRestClient client = null)
        {
            PagingQueryParams queryParams = new PagingQueryParams(page, pageSize);

            return Get<Number>(BuildGetLocalUrl(accountId), queryParams, client: client);
        }

        /// <summary>
        /// Creates a phone number.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="createNumber">CreateNumber.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static Number Create(int accountId, CreateNumber createNumber, IVcRestClient client = null)
        {
            return Create<Number>(BuildCreateUrl(accountId), createNumber, client: client);
        }

        /// <summary>
        /// Creates a local phone number.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="createNumberLocal">CreateNumberLocal.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static Number CreateLocal(int accountId, CreateNumberLocal createNumberLocal, IVcRestClient client = null)
        {
            return Create<Number>(BuildCreateLocalUrl(accountId), createNumberLocal, client: client);
        }

        /// <summary>
        /// Deletes the phone number.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="id">Phone number ID.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static bool Delete(int accountId, int id, IVcRestClient client = null)
        {
            return Delete(BuildDeleteUrl(accountId, id), client);
        }

        /// <summary>
        /// Deletes the local phone number.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="id">Phone number ID.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static bool DeleteLocal(int accountId, int id, IVcRestClient client = null)
        {
            return Delete(BuildDeleteLocalUrl(accountId, id), client);
        }

        /// <summary>
        /// Builds the create URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <returns></returns>
        private static string BuildCreateUrl(int accountId)
        {
            return string.Format(EndpointNumbers, accountId);
        }

        /// <summary>
        /// Builds the create local URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <returns></returns>
        private static string BuildCreateLocalUrl(int accountId)
        {
            return string.Format(EndpointNumbersLocal, accountId);
        }

        /// <summary>
        /// Builds the get by page URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <returns></returns>
        private static string BuildGetUrl(int accountId)
        {
            return string.Format(EndpointNumbers, accountId);
        }

        /// <summary>
        /// Builds the get by page local URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <returns></returns>
        private static string BuildGetLocalUrl(int accountId)
        {
            return string.Format(EndpointNumbersLocal, accountId);
        }

        /// <summary>
        /// Builds the get available URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <returns></returns>
        private static string BuildGetAvailableUrl(int accountId)
        {
            return string.Format(EndpointNumbersAvailable, accountId);
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
        /// Builds the count local URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <returns></returns>
        private static string BuildCountLocalUrl(int accountId)
        {
            return string.Format(EndpointNumbersLocalCount, accountId);
        }

        /// <summary>
        /// Builds the get URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="id">Phone number ID.</param>
        /// <returns></returns>
        private static string BuildGetSingleUrl(int accountId, int id)
        {
            return string.Format(EndpointNumberId, accountId, id);
        }

        /// <summary>
        /// Builds the get local URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="id">Phone number ID.</param>
        /// <returns></returns>
        private static string BuildGetSingleLocalUrl(int accountId, int id)
        {
            return string.Format(EndpointNumberLocalId, accountId, id);
        }

        /// <summary>
        /// Builds the update URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="id">Phone number ID.</param>
        /// <returns></returns>
        private static string BuildUpdateUrl(int accountId, int id)
        {
            return string.Format(EndpointNumberId, accountId, id);
        }

        /// <summary>
        /// Builds the update local URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="id">Phone number ID.</param>
        /// <returns></returns>
        private static string BuildUpdateLocalUrl(int accountId, int id)
        {
            return string.Format(EndpointNumberLocalId, accountId, id);
        }

        /// <summary>
        /// Builds the delete URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="id">Phone number ID.</param>
        /// <returns></returns>
        private static string BuildDeleteUrl(int accountId, int id)
        {
            return string.Format(EndpointNumberId, accountId, id);
        }

        /// <summary>
        /// Builds the delete local URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="id">Phone number ID.</param>
        /// <returns></returns>
        private static string BuildDeleteLocalUrl(int accountId, int id)
        {
            return string.Format(EndpointNumberLocalId, accountId, id);
        }

        /// <summary>
        /// Builds the lookup URL.
        /// </summary>
        /// <param name="accountid">Account ID.</param>
        /// <returns></returns>
        private static string BuildLookupUrl(int accountid)
        {
            return string.Format(EndpointNumbersLookup, accountid);
        }
    }
}
