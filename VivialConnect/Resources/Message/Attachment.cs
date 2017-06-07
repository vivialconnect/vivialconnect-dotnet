using System;

using Newtonsoft.Json;
using VivialConnect.Http;

namespace VivialConnect.Resources.Message
{
    /// <summary>
    /// Attachment details.
    /// </summary>
    /// <seealso cref="VivialConnect.Resources.ResourceEntity" />
    public class Attachment : ResourceEntity
    {
        /// <summary>
        /// The account ID.
        /// </summary>
        /// <value>
        /// Account ID.
        /// </value>
        [JsonProperty("account_id")]
        public int AccountId { get; private set; }

        /// <summary>
        /// Mime-type of the media attachment.
        /// </summary>
        /// <value>
        /// Content type.
        /// </value>
        [JsonProperty("content_type")]
        public string ContentType { get; private set; }

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
        /// The file name of the media attachment.
        /// </summary>
        /// <value>
        /// File name.
        /// </value>
        [JsonProperty("file_name")]
        public string FileName { get; private set; }

        /// <summary>
        /// The attachment ID.
        /// </summary>
        /// <value>
        /// ID.
        /// </value>
        [JsonProperty("id")]
        public int Id { get; private set; }

        /// <summary>
        /// The unique identifier of the text message for the media attachment.
        /// </summary>
        /// <value>
        /// Message ID.
        /// </value>
        [JsonProperty("message_id")]
        public int MessageId { get; private set; }

        /// <summary>
        /// The size of the media attachment in bytes.
        /// </summary>
        /// <value>
        /// Size.
        /// </value>
        [JsonProperty("size")]
        public int Size { get; private set; }

        /// <summary>
        /// Get's the media for the attachment if any.
        /// </summary>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public Media Media(IVcRestClient client = null)
        {
            return GetMedia(this.AccountId, this.MessageId, this.Id, client);
        }

        /// <summary>
        /// Gets the media for the specified attachment.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="messageId">Message ID.</param>
        /// <param name="id">Attachment ID.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static Media GetMedia(int accountId, int messageId, int id, IVcRestClient client = null)
        {
            client = client ?? VcClient.GetRestClient();
            Request request = new Request(Method.Get, Message.BuildGetAttachmentUrl(accountId, messageId, id, asJson: false));
            Response response = client.Request(request);

            return new Media(response.Content, response.ContentEncoding, response.ContentLength, response.RawBytes, response.ResponseUri);
        }

        
    }
}
