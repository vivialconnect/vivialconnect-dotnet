using System;
using System.Collections.Generic;
using System.Net;

using Newtonsoft.Json;
using VivialConnect.Http;

namespace VivialConnect.Resources.User
{
    /// <summary>
    /// Resource used to manage users and user passwords.
    /// </summary>
    /// <seealso cref="VivialConnect.Resources.ResourceEntity" />
    public class User : ResourceEntity
    {
        private const string EndpointUsers = "/accounts/{0}/users.json";
        private const string EndpointUserId = "/accounts/{0}/users/{1}.json";
        private const string EndpointCount = "/accounts/{0}/users/count.json";
        private const string EndpointUpdatePassword = "/accounts/{0}/users/{1}/profile/password.json";

        /// <summary>
        /// The account ID the user is assigned to.
        /// </summary>
        /// <value>
        /// Account ID.
        /// </value>
        [JsonProperty("account_id")]
        public int AccountId { get; private set; }

        /// <summary>
        /// Value indicating whether this <see cref="Resources.User"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("active")]
        public bool Active { get; private set; }

        /// <summary>
        /// The API key.
        /// </summary>
        /// <value>
        /// API key.
        /// </value>
        [JsonProperty("api_key")]
        public string ApiKey { get; private set; }

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
        /// The user's email.
        /// </summary>
        /// <value>
        /// Email.
        /// </value>
        [JsonProperty("email")]
        public string Email { get; private set; }

        /// <summary>
        /// The user's first name.
        /// </summary>
        /// <value>
        /// First name.
        /// </value>
        [JsonProperty("first_name")]
        public string FirstName { get; private set; }

        /// <summary>
        /// The user ID.
        /// </summary>
        /// <value>
        /// User ID.
        /// </value>
        [JsonProperty("id")]
        public int Id { get; private set; }

        /// <summary>
        /// The user's last name.
        /// </summary>
        /// <value>
        /// Last name.
        /// </value>
        [JsonProperty("last_name")]
        public string LastName { get; private set; }

        /// <summary>
        /// The roles assigned to the user.
        /// </summary>
        /// <value>
        /// Roles.
        /// </value>
        [JsonProperty("roles")]
        public List<Role> Roles { get; private set; }

        /// <summary>
        /// The timezone.
        /// </summary>
        /// <value>
        /// Timezone.
        /// </value>
        [JsonProperty("timezone")]
        public string Timezone { get; private set; }

        /// <summary>
        /// The user’s username for logging in to the account.
        /// </summary>
        /// <value>
        /// Username.
        /// </value>
        [JsonProperty("username")]
        public string Username { get; private set; }

        /// <summary>
        /// Value indicating whether this <see cref="Resources.User"/> is verified.
        /// </summary>
        /// <value>
        ///   <c>true</c> if verified; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("verified")]
        public bool Verified { get; private set; }

        /// <summary>
        /// Updates the user's password.
        /// </summary>
        /// <param name="oldPassword">Old password.</param>
        /// <param name="newPassword">New password.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public bool UpdatePassword(string oldPassword, string newPassword, IVcRestClient client = null)
        {
            return UpdatePassword(this.Id, oldPassword, newPassword, client);
        }

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public bool Delete(IVcRestClient client = null)
        {
            return Delete(VcClient.AccountId, this.Id, client);
        }

        /// <summary>
        /// Gets the specified user associated to the master account.
        /// </summary>
        /// <param name="id">User ID.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public static User FindSingle(int id, IVcRestClient client = null)
        {
            return GetSingle(VcClient.AccountId, id, client);
        }

        /// <summary>
        /// Gets users for account.
        /// </summary>
        /// <param name="page">Page.</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public static List<User> Find(int page = DefaultPage, int pageSize = DefaultPageSize, IVcRestClient client = null)
        {
            return Get(VcClient.AccountId, page, pageSize, client);
        }

        /// <summary>
        /// Deletes the specified user.
        /// </summary>
        /// <param name="id">User ID.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public static bool Delete(int id, IVcRestClient client = null)
        {
            return Delete(VcClient.AccountId, id, client);
        }

        /// <summary>
        /// Updates the specified user's password.
        /// </summary>
        /// <param name="id">User ID.</param>
        /// <param name="oldPassword">Old password.</param>
        /// <param name="newPassword">New password.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public static bool UpdatePassword(int id, string oldPassword, string newPassword, IVcRestClient client = null)
        {
            return UpdatePassword(VcClient.AccountId, id, oldPassword, newPassword, client);
        }

        /// <summary>
        /// Gets count of all users for master account.
        /// </summary>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        public static int Count(IVcRestClient client = null)
        {
            return Count(VcClient.AccountId, client);
        }

        /// <summary>
        /// Gets the specified user.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="id">User ID.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static User GetSingle(int accountId, int id, IVcRestClient client = null)
        {
            return GetSingle<User>(BuildGetSingleUrl(accountId, id), client: client);
        }

        /// <summary>
        /// Gets count of all users for specified account.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static int Count(int accountId, IVcRestClient client = null)
        {
            return Count(string.Format(EndpointCount, accountId), client: client);
        }

        /// <summary>
        /// Gets all users for specified account.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="page">Page</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static List<User> Get(int accountId, int page = DefaultPage, int pageSize = DefaultPageSize, IVcRestClient client = null)
        {
            PagingQueryParams queryParams = new PagingQueryParams(page, pageSize);
            return Get<User>(BuildGetUrl(accountId), queryParams, client: client);
        }

        /// <summary>
        /// Updates the user password.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="id">User ID.</param>
        /// <param name="oldPassword">Old password.</param>
        /// <param name="newPassword">New password.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static bool UpdatePassword(int accountId, int id, string oldPassword, string newPassword, IVcRestClient client = null)
        {
            UpdatePassword updatePassword = new UpdatePassword { OldPassword = oldPassword, NewPassword = newPassword };

            return UpdatePassword(accountId, id, updatePassword, client);
        }

        /// <summary>
        /// Updates the user password.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="id">User ID.</param>
        /// <param name="updatePassword">Update password.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static bool UpdatePassword(int accountId, int id, UpdatePassword updatePassword, IVcRestClient client = null)
        {
            client = client ?? VcClient.GetRestClient();
            Request request = new Request(Method.Put, BuildUpdatePasswordUrl(accountId, id), updatePassword);
            Response response = client.Request(request);

            return response.StatusCode == HttpStatusCode.OK;
        }

        /// <summary>
        /// Deletes the specified user.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="id">User ID.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static bool Delete(int accountId, int id, IVcRestClient client = null)
        {
            return Delete(BuildDeleteUrl(accountId, id), client);
        }

        /// <summary>
        /// Builds the get URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <returns></returns>
        private static string BuildGetUrl(int accountId)
        {
            return string.Format(EndpointUsers, accountId);
        }

        /// <summary>
        /// Builds the get single URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="id">User ID.</param>
        /// <returns></returns>
        private static string BuildGetSingleUrl(int accountId, int id)
        {
            return string.Format(EndpointUserId, accountId, id);
        }

        /// <summary>
        /// Builds the delete URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="id">User ID.</param>
        /// <returns></returns>
        private static string BuildDeleteUrl(int accountId, int id)
        {
            return string.Format(EndpointUserId, accountId, id);
        }

        /// <summary>
        /// Builds the update password URL.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="id">User ID.</param>
        /// <returns></returns>
        private static string BuildUpdatePasswordUrl(int accountId, int id)
        {
            return string.Format(EndpointUpdatePassword, accountId, id);
        }
    }
}
