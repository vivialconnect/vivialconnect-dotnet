using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VivialConnect.Http;
using VivialConnect.Mappings;

namespace VivialConnect.Resources.Message
{
    /// <summary>
    /// Resource used for managing messages and attachments.
    /// </summary>
    /// <seealso cref="VivialConnect.Resources.ResourceEntity" />
    public class Message : ResourceEntity
    {
        private const string EndpointMessages = "/accounts/{0}/messages.json";
        private const string EndpointCount = "/accounts/{0}/messages/count.json";
        private const string EndpointMessageId = "accounts/{0}/messages/{1}.json";
        private const string EndpointAttachments = "/accounts/{0}/messages/{1}/attachments.json";
        private const string EndpointAttachmentsCount = "/accounts/{0}/messages/{1}/attachments/count.json";
        private const string EndpointAttachmentId = "/accounts/{0}/messages/{1}/attachments/{2}{3}";
        private const string EndpointBulkJob = "/accounts/{0}/messages/bulk.json";
        private const string EndpointBulkJobMessages = "/accounts/{0}/messages/bulk/{1}.json";


        private Message() { }

        /// <summary>
        /// The unique identifier of the text message object.
        /// </summary>
        /// <value>
        /// Message ID.
        /// </value>
        [JsonProperty("id")]
        public int? Id { get; private set; }

        /// <summary>
        /// The unique identifier of the account or subaccount 
        /// associated with the text message.
        /// </summary>
        /// <value>
        /// Account ID.
        /// </value>
        [JsonProperty("account_id")]
        public int AccountId { get; private set; }

        /// <summary>
        /// The text body of the text message.
        /// </summary>
        /// <value>
        /// Body.
        /// </value>
        [JsonProperty("body")]
        public string Body { get; private set; }

        /// <summary>
        /// The ID of the Connector to use to
        /// send the message with.
        /// </summary>
        /// <value>
        /// Connector ID.
        /// </value>
        [JsonProperty("connector_id")]
        public int? ConnectorId { get; set; }

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
        /// The inbound/outbound direction of the text message, 
        /// and if outbound, the nature of the text message initiation.
        /// </summary>
        /// <value>
        /// Direction.
        /// </value>
        [JsonProperty("direction")]
        public string Direction { get; private set; }

        /// <summary>
        /// The error code, if any, for the message.
        /// </summary>
        /// <value>
        /// Error code.
        /// </value>
        [JsonProperty("error_code")]
        public string ErrorCode { get; private set; }

        /// <summary>
        /// The error code message for error code as it is displayed to users.
        /// </summary>
        /// <value>
        /// Error message.
        /// </value>
        [JsonProperty("error_message")]
        public string ErrorMessage { get; private set; }

        /// <summary>
        /// External phone number that sent the text message, for inbound messages.
        /// For outbound messages, the associated phone number in your account that sent
        /// the text message.
        /// </summary>
        /// <value>
        /// From number.
        /// </value>
        [JsonProperty("from_number")]
        public string FromNumber { get; private set; }

        /// <summary>
        /// The type of message.
        /// </summary>
        /// <value>
        /// Message type.
        /// </value>
        [JsonProperty("message_type")]
        public string MessageType { get; private set; }

        /// <summary>
        /// The number of media attachments for the text message.
        /// </summary>
        /// <value>
        /// Number media.
        /// </value>
        [JsonProperty("num_media")]
        public int? NumMedia { get; private set; }

        /// <summary>
        /// The number of segments that make up the message. 
        /// </summary>
        /// <value>
        /// Number segments.
        /// </value>
        [JsonProperty("num_segments")]
        public int? NumSegments { get; private set; }

        /// <summary>
        /// The amount billed for the message, in the currency 
        /// associated with the account.
        /// </summary>
        /// <value>
        /// Price.
        /// </value>
        [JsonProperty("price")]
        public decimal? Price { get; private set; }

        /// <summary>
        /// The currency in which price is measured in ISO 4127 format. 
        /// For US, the currency will be USD.
        /// </summary>
        /// <value>
        /// Price currency.
        /// </value>
        [JsonProperty("price_currency")]
        public string PriceCurrency { get; private set; }

        /// <summary>
        /// The date the text message was received if inbound or the date the
        /// text message was sent if outbound.
        /// </summary>
        /// <value>
        /// Sent.
        /// </value>
        [JsonProperty("sent")]
        public DateTime? Sent { get; private set; }
        
        /// <summary>
        /// The status of the message.
        /// </summary>
        /// <value>
        /// Status.
        /// </value>
        [JsonProperty("status")]
        public string Status { get; private set; }

        /// <summary>
        /// The phone number that received the text message. 
        /// </summary>
        /// <value>
        /// To number.
        /// </value>
        [JsonProperty("to_number")]
        public string ToNumber { get; private set; }

        /// <summary>
        /// Redacts the text message.
        /// </summary>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public void Redact(IVcRestClient client = null)
        {
            Message message = Update(this.AccountId, (int)this.Id, client);
            ResourceConfiguration.GetMapper().Map(message, this);
        }

        /// <summary>
        /// Gets an attachment for message by ID.
        /// </summary>
        /// <param name="id">Attachment ID.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public Attachment Attachment(int id, IVcRestClient client = null)
        {
            return GetAttachment(VcClient.AccountId, (int)this.Id, id, client);
        }

        /// <summary>
        /// Gets all attachments for message.
        /// </summary>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public List<Attachment> Attachments(IVcRestClient client = null)
        {
            return GetAllAttachments(VcClient.AccountId, (int)this.Id, client);
        }

        /// <summary>
        /// Gets all bulk jobs for account.
        /// </summary>
        /// <param name="client">REST client.</param>
        /// <returns>Build jobs.</returns>
        public static List<BulkJob> BulkJobs(IVcRestClient client = null)
        {
            return Get<BulkJob>(BuildGetBulkJobsUrl(VcClient.AccountId), client: client);
        }

        /// <summary>
        /// Gets the messages for a bulk job.
        /// </summary>
        /// <param name="bulkJobId">Bulk job ID.</param>
        /// <param name="client">REST client.</param>
        /// <returns>Messages</returns>
        public static List<Message> BulkJobMessages(string bulkJobId, IVcRestClient client = null)
        {
            return Get<Message>(BuildGetBulkJobMessagesUrl(VcClient.AccountId, bulkJobId), client: client);
        }

        /// <summary>
        /// Gets a message by ID.
        /// </summary>
        /// <param name="id">Message ID.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public static Message FindSingle(int id, IVcRestClient client = null)
        {
            return GetSingle(VcClient.AccountId, id, client);
        }

        /// <summary>
        /// Gets messages.
        /// </summary>
        /// <param name="page">Page.</param>
        /// <param name="pageSize">Page Size.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public static List<Message> Find(int page = DefaultPage, int pageSize = DefaultPageSize, IVcRestClient client = null)
        {
            return Get(VcClient.AccountId, page, pageSize, client);
        }

        /// <summary>
        /// Sends a message.
        /// </summary>
        /// <param name="toNumber">To number.</param>
        /// <param name="fromNumber">From number.</param>
        /// <param name="body">Body.</param>
        /// <param name="mediaUrls">Media Urls.</param>
        /// <param name="connectorId">Connector ID.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public static Message Send(string toNumber, string fromNumber, string body = null, List<string> mediaUrls = null, int? connectorId = null, IVcRestClient client = null)
        {
            return Create(VcClient.AccountId, toNumber, fromNumber, body, mediaUrls, connectorId, client);
        }

        /// <summary>
        /// Send a message to multiple numbers with one request.
        /// </summary>
        /// <param name="toNumbers">To numbers.</param>
        /// <param name="fromNumber">From number.</param>
        /// <param name="connectorId">Connector ID.</param>
        /// <param name="body">Body.</param>
        /// <param name="mediaUrls">Media Urls.</param>
        /// <param name="client">REST client.</param>
        /// <returns>Builk Job Id</returns>
        public static string SendBulk(List<string> toNumbers, string fromNumber = null, int? connectorId = null, string body = null, List<string> mediaUrls = null, IVcRestClient client = null)
        {
            return CreateBulkJob(VcClient.AccountId, toNumbers, fromNumber, connectorId, body, mediaUrls, client);
        }

        /// <summary>
        /// Count of messages.
        /// </summary>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public static int Count(IVcRestClient client = null)
        {
            return Count(VcClient.AccountId, client);
        }

        /// <summary>
        /// Gets a message by ID.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="id">Message ID.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static Message GetSingle(int accountId, int id, IVcRestClient client = null)
        {
            return GetSingle<Message>(BuildGetSingleUrl(accountId, id), client: client);
        }

        /// <summary>
        /// Gets an attachment by ID.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="messageId">Message ID.</param>
        /// <param name="id">Attachment ID.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static Attachment GetAttachment(int accountId, int messageId, int id, IVcRestClient client = null)
        {
            return GetSingle<Attachment>(BuildGetAttachmentUrl(accountId, messageId, id), client: client);
        }

        /// <summary>
        /// Count of messages for the specified account.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static int Count(int accountId, IVcRestClient client = null)
        {
            return Count(BuildCountUrl(accountId), client: client);
        }

        /// <summary>
        /// Count of attachments for the specified message.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="messageId">Message ID.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static int CountAttachments(int accountId, int messageId, IVcRestClient client = null)
        {
            return Count(BuildCountAttachmentsUrl(accountId, messageId), client: client);
        }

        /// <summary>
        /// Gets messages for the specified account.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="page">Page.</param>
        /// <param name="pageSize">Page Size.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static List<Message> Get(int accountId, int page = DefaultPage, int pageSize = DefaultPageSize, IVcRestClient client = null)
        {
            PagingQueryParams queryParams = new PagingQueryParams(page, pageSize);

            return Get<Message>(BuildGetUrl(accountId), queryParams, client: client);
        }

        /// <summary>
        /// Gets all attachments for the specified message.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="messageId">Message ID.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static List<Attachment> GetAllAttachments(int accountId, int messageId, IVcRestClient client = null)
        {
            return GetAll<Attachment>(CountAttachments(accountId, messageId, client), BuildGetAttachmentsUrl(accountId, messageId), client: client);
        }

        /// <summary>
        /// Creates a message under the specified account.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="toNumber">To number.</param>
        /// <param name="fromNumber">From number.</param>
        /// <param name="body">Body.</param>
        /// <param name="mediaUrls">Media Urls.</param>
        /// <param name="connectorId">Connector ID.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static Message Create(int accountId, string toNumber, string fromNumber, string body = null, List<string> mediaUrls = null, int? connectorId = null, IVcRestClient client = null)
        {
            CreateMessage createMessage = new CreateMessage(toNumber, fromNumber)
            {
                Body = body,
                MediaUrls = mediaUrls,
                ConnectorId = connectorId
            };

            return Create(accountId, createMessage, client);
        }

        /// <summary>
        /// Creates a message under the specified account.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="createMessage">CreateMessage.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static Message Create(int accountId, CreateMessage createMessage, IVcRestClient client = null)
        {
            return Create<Message>(BuildCreateUrl(accountId), createMessage, client: client);
        }

        /// <summary>
        /// Creates a bulk job under the specified account.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="toNumbers">To numbers.</param>
        /// <param name="fromNumber">From number.</param>
        /// <param name="connectorId">Connector ID.</param>
        /// <param name="body">Body.</param>
        /// <param name="mediaUrls">Media Urls.</param>
        /// <param name="client">REST clinet.</param>
        /// <returns>Bulk Job ID</returns>
        private static string CreateBulkJob(int accountId, List<string> toNumbers, string fromNumber = null, int? connectorId = null, string body = null, List<string> mediaUrls = null, IVcRestClient client = null)
        {
            CreateBulkJob createBulkJob = new CreateBulkJob(toNumbers)
            {
                FromNumber = fromNumber,
                ConnectorId = connectorId,
                Body = body,
                MediaUrls = mediaUrls
            };

            return CreateBulkJob(accountId, createBulkJob, client);
        }

        /// <summary>
        /// Creates a bulk job under the specified account.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="createBulkJob">CreateBulkJob.</param>
        /// <param name="client">REST client.</param>
        /// <returns>Bulk Job ID</returns>
        private static string CreateBulkJob(int accountId, CreateBulkJob createBulkJob, IVcRestClient client = null)
        {
            string content = CreateRawContent(BuildCreateBulkJobUrl(accountId), createBulkJob, client);
            JObject json = JObject.Parse(content);

            return json.First.First.ToString();
        }

        /// <summary>
        /// Updates the specified message.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="id">Message ID.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static Message Update(int accountId, int id, IVcRestClient client = null)
        {
            UpdateMessage updateMessage = new UpdateMessage { Id = id };

            return Update<Message>(BuildUpdateUrl(accountId, id), updateMessage, client: client);
        }

        /// <summary>
        /// Builds the count message URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <returns></returns>
        private static string BuildCountUrl(int accountId)
        {
            return string.Format(EndpointCount, accountId);
        }

        /// <summary>
        /// Builds the count attachments URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="messageId">Message ID.</param>
        /// <returns></returns>
        private static string BuildCountAttachmentsUrl(int accountId, int messageId)
        {
            return string.Format(EndpointAttachmentsCount, accountId, messageId);
        }

        /// <summary>
        /// Builds the get URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <returns></returns>
        private static string BuildGetUrl(int accountId)
        {
            return string.Format(EndpointMessages, accountId);
        }

        /// <summary>
        /// Builds the get attachments by page URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="messageId">Message ID.</param>
        /// <returns></returns>
        private static string BuildGetAttachmentsUrl(int accountId, int messageId)
        {
            return string.Format(EndpointAttachments, accountId, messageId);
        }

        /// <summary>
        /// Builds the get single message URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="id">Message ID.</param>
        /// <returns></returns>
        private static string BuildGetSingleUrl(int accountId, int id)
        {
            return string.Format(EndpointMessageId, accountId, id);
        }        

        /// <summary>
        /// Builds the create URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <returns></returns>
        private static string BuildCreateUrl(int accountId)
        {
            return string.Format(EndpointMessages, accountId);
        }

        /// <summary>
        /// Builds the create bulk job URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <returns></returns>
        private static string BuildCreateBulkJobUrl(int accountId)
        {
            return string.Format(EndpointBulkJob, accountId);
        }

        /// <summary>
        /// Builds the get bulk jobs URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <returns></returns>
        private static string BuildGetBulkJobsUrl(int accountId)
        {
            return string.Format(EndpointBulkJob, accountId);
        }

        /// <summary>
        /// Builds the get bulk job messages URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="bulkJobId">Bulk job ID.</param>
        /// <returns></returns>
        private static string BuildGetBulkJobMessagesUrl(int accountId, string bulkJobId)
        {
            return string.Format(EndpointBulkJobMessages, accountId, bulkJobId);
        }

        /// <summary>
        /// Builds the update URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="id">Message ID.</param>
        /// <returns></returns>
        private static string BuildUpdateUrl(int accountId, int id)
        {
            return string.Format(EndpointMessageId, accountId, id);
        }

        /// <summary>
        /// Builds the get attachment URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="messageId">Message ID.</param>
        /// <param name="id">Attachment ID.</param>
        /// <param name="asJson">if set to <c>true</c> [as json].</param>
        /// <returns></returns>
        internal static string BuildGetAttachmentUrl(int accountId, int messageId, int id, bool asJson = true)
        {
            return string.Format(EndpointAttachmentId, accountId, messageId, id, asJson ? ".json" : string.Empty);
        }
    }
}
