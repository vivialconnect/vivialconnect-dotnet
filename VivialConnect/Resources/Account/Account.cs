using System;
using System.Collections.Generic;

using AutoMapper;
using Newtonsoft.Json;
using VivialConnect.Http;

namespace VivialConnect.Resources.Account
{
    /// <summary>
    /// Resource used for managing accounts and logs.
    /// </summary>
    /// <seealso cref="VivialConnect.Resources.ResourceEntity" />
    public class Account : ResourceEntity
    {
        private const string EndpointAccountId = "/accounts/{0}.json";
        private const string EndpointLogs = "/accounts/{0}/logs.json";
        private const string EndpointLogsAggregate = "/accounts/{0}/logs/aggregate.json";

        /// <summary>
        /// Prevents a default instance of the <see cref="Account"/> class.
        /// </summary>
        private Account() { }

        /// <summary>
        /// The account ID.
        /// </summary>
        /// <value>
        /// Account ID.
        /// </value>
        [JsonProperty("id")]
        public int Id { get; private set; }

        /// <summary>
        /// Value indicating whether this <see cref="Resources.Account"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("active")]
        public bool Active { get; private set; }

        /// <summary>
        /// The name of the company.
        /// </summary>
        /// <value>
        /// Name of the company.
        /// </value>
        [JsonProperty("company_name")]
        public string CompanyName { get; set; }

        /// <summary>
        /// The contacts.
        /// </summary>
        /// <value>
        /// Contacts.
        /// </value>
        [JsonProperty("contacts")]
        public List<Contact> Contacts { get; private set; }

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
        /// The account services.
        /// </summary>
        /// <value>
        /// Account services.
        /// </value>
        [JsonProperty("services")]
        public List<Service> Services { get; private set; }

        /// <summary>
        /// Saves updates to the account.
        /// </summary>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public void Save(IVcRestClient client = null)
        {
            UpdateAccount updateAccount = new UpdateAccount { Id = this.Id, CompanyName = this.CompanyName };

            Account account = Update(updateAccount, client);
            Mapper.Map(account, this);
        }

        /// <summary>
        /// Gets the account.
        /// </summary>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public static Account FindSingle(IVcRestClient client = null)
        {
            return FindSingle(VcClient.AccountId, client);
        }

        /// <summary>
        /// Gets the account.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public static Account FindSingle(int accountId, IVcRestClient client = null)
        {
            return GetSingle(accountId, client: client);
        }

        /// <summary>
        /// Gets logs for account.
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="itemId"></param>
        /// <param name="limit"></param>
        /// <param name="logType"></param>
        /// <param name="operatorId"></param>
        /// <param name="startKey"></param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public static AccountLogs GetLogs(DateTime startTime,
                                        DateTime endTime,
                                        int? itemId = null,
                                        int? limit = null,
                                        string logType = null,
                                        int? operatorId = null,
                                        string startKey = null,
                                        IVcRestClient client = null)
        {
            AccountLogsQueryParams queryParams = new AccountLogsQueryParams(startTime, endTime)
            {
                ItemId = itemId,
                Limit = limit,
                LogType = logType,
                OperatorId = operatorId,
                StartKey = startKey
            };

            return GetLogs(queryParams, client);
        }

        /// <summary>
        /// Gets aggregate logs for account.
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="aggregatorType"></param>
        /// <param name="limit"></param>
        /// <param name="logType"></param>
        /// <param name="operatorId"></param>
        /// <param name="startKey"></param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public static AccountLogsAggregate GetLogsAggregate(DateTime startTime,
                                                            DateTime endTime,
                                                            AggregatorTypeEnum aggregatorType,
                                                            int? limit = null,
                                                            string logType = null,
                                                            int? operatorId = null,
                                                            string startKey = null,
                                                            IVcRestClient client = null)
        {
            AccountLogsAggregateQueryParams queryParams = new AccountLogsAggregateQueryParams(startTime, endTime, aggregatorType)
            {
                Limit = limit,
                LogType = logType,
                OperatorId = operatorId,
                StartKey = startKey
            };

            return GetLogsAggregate(queryParams, client);
        }

        /// <summary>
        /// Gets an account for the specified ID.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static Account GetSingle(int accountId, IVcRestClient client = null)
        {
            return GetSingle<Account>(BuildGetSingleUrl(accountId), client: client);
        }

        /// <summary>
        /// Gets logs for account.
        /// </summary>
        /// <param name="queryParams">AccountsLogsQueryParams.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static AccountLogs GetLogs(AccountLogsQueryParams queryParams, IVcRestClient client = null)
        {
            return GetSingle<AccountLogs>(BuildGetLogsUrl(VcClient.AccountId), queryParams, includeRoot: true, client: client);            
        }

        /// <summary>
        /// Gets aggregate logs for the specified account.
        /// </summary>
        /// <param name="queryParams">Query parameters.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static AccountLogsAggregate GetLogsAggregate(AccountLogsAggregateQueryParams queryParams, IVcRestClient client = null)
        {
            return GetSingle<AccountLogsAggregate>(BuildGetLogsAggregateUrl(VcClient.AccountId), queryParams, includeRoot: true, client: client);
        }

        /// <summary>
        /// Updates account based on "UpdateAccount" object.
        /// </summary>
        /// <param name="updateAccount">Update Account.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static Account Update(UpdateAccount updateAccount, IVcRestClient client = null)
        {
            return Update<Account>(BuildUpdateUrl(updateAccount.Id), updateAccount, client: client);
        }

        /// <summary>
        /// Builds the get URL.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private static string BuildGetSingleUrl(int id)
        {
            return string.Format(EndpointAccountId, id);
        }

        /// <summary>
        /// Builds the update URL.
        /// </summary>
        /// <param name="id">Account ID.</param>
        /// <returns></returns>
        private static string BuildUpdateUrl(int id)
        {
            return string.Format(EndpointAccountId, id);
        }

        /// <summary>
        /// Builds the get logs URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <returns></returns>
        private static string BuildGetLogsUrl(int accountId)
        {
            return string.Format(EndpointLogs, accountId);
        }

        /// <summary>
        /// Builds the get logs aggregate URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <returns></returns>
        private static string BuildGetLogsAggregateUrl(int accountId)
        {
            return string.Format(EndpointLogsAggregate, accountId);
        }
    }
}
