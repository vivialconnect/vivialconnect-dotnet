using Newtonsoft.Json;
using System;

namespace VivialConnect.Resources.Message
{
    /// <summary>
    /// Bulk job details.
    /// </summary>
    /// <seealso cref="VivialConnect.Resources.ResourceEntity" />
    public class BulkJob : IResourceEntity
    {
        /// <summary>
        /// The bulk ID.
        /// </summary>
        /// <value>
        /// Bulk ID
        /// </value>
        [JsonProperty("bulk_id")]
        public string BulkId { get; private set; }

        /// <summary>
        /// The total messages in the bulk job.
        /// </summary>
        /// <value>
        /// Total messsages.
        /// </value>
        [JsonProperty("total_messages")]
        public int TotalMessages { get; private set; }

        /// <summary>
        /// The date created.
        /// </summary>
        /// <value>
        /// Date created.
        /// </value>
        [JsonProperty("date_created")]
        public DateTime DateCreated { get; private set; }

        /// <summary>
        /// The number of messages processed.
        /// </summary>
        /// <value>
        /// Processed.
        /// </value>
        [JsonProperty("processed")]
        public int Processed { get; private set; }

        /// <summary>
        /// The number of failed messages.
        /// </summary>
        /// <value>
        /// Errors.
        /// </value>
        [JsonProperty("errors")]
        public int Errors { get; private set; }

        /// <summary>
        /// Not applicable.
        /// </summary>
        public bool IsNew => throw new NotImplementedException();
    }
}
