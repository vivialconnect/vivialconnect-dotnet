using System.Collections.Generic;
using System.Net;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VivialConnect.Http;

namespace VivialConnect.Resources
{
    /// <summary>
    /// Base class for Account, Connector, Message, Number and User resources.
    /// </summary>
    public abstract class Resource
    {
        public const int DefaultPage = 1;
        public const int DefaultPageSize = 50;
        public const string DefaultEmptyString = "";

        /// <summary>
        /// Initializes a new instance of the <see cref="Resource"/> class.
        /// </summary>
        public Resource(){}

        /// <summary>
        /// Executes Get requests to retrieve all items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="totalCount">Total count.</param>
        /// <param name="getByPageUrl">Get by page URL.</param>
        /// <param name="queryParams">Query parameters.</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        protected static List<T> GetAll<T>(int totalCount, string getByPageUrl, IQueryParams queryParams = null, int pageSize = DefaultPageSize, IVcRestClient client = null) where T : IResourceEntity
        {
            int count = totalCount;
            int page = 1;
            List<T> entities = new List<T>();

            while (count > 0)
            {
                if(queryParams == null)
                {
                    queryParams = new PagingQueryParams(page, pageSize);
                }
                else
                {
                    ((IPagingQueryParams)queryParams).Page = page;
                    ((IPagingQueryParams)queryParams).PageSize = pageSize;
                }

                entities.AddRange(Get<T>(getByPageUrl, queryParams, client: client));
                page++;
                count -= pageSize;
            }

            return entities;
        }

        /// <summary>
        /// Executes a Count request.
        /// </summary>
        /// <param name="url">URL.</param>
        /// <param name="queryParams">Query parameters.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        protected static int Count(string url, IQueryParams queryParams = null, IVcRestClient client = null)
        {
            client = client ?? VcClient.GetRestClient();
            Request request = new Request(Method.Get, url, queryParams);
            Response response = client.Request(request);
            JObject json = JObject.Parse(response.Content);

            return JsonConvert.DeserializeObject<int>(json.First.First.ToString());
        }

        /// <summary>
        /// Executes a Get request that returns a single instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">URL.</param>
        /// <param name="queryParams">Query parameters.</param>
        /// <param name="includeRoot">if set to <c>true</c> [include root].</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        protected static T GetSingle<T> (string url, QueryParams queryParams = null, bool includeRoot = false, JsonConverter[] jsonConverters = null, IVcRestClient client = null) where T : IResourceEntity
        {
            client = client ?? VcClient.GetRestClient();
            Request request = new Request(Method.Get, url, queryParams);
            Response response = client.Request(request);
            JObject json = JObject.Parse(response.Content);

            return JsonConvert.DeserializeObject<T>(includeRoot == true ? json.ToString() : json.First.First.ToString(), jsonConverters);
        }

        /// <summary>
        /// Executes a Get request that returns a list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">Request URL.</param>
        /// <param name="queryParams">Query string parameters.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        protected static List<T> Get<T> (string url, IQueryParams queryParams=null, JsonConverter[] jsonConverters = null, IVcRestClient client = null) where T : IResourceEntity
        {
            client = client ?? VcClient.GetRestClient();
            Request request = new Request(Method.Get, url, queryParams);
            Response response = client.Request(request);
            JObject json = JObject.Parse(response.Content);

            return JsonConvert.DeserializeObject<List<T>>(json.First.First.ToString(), jsonConverters);
        }

        /// <summary>
        /// Executes a Get request that returns the raw content.
        /// </summary>
        /// <param name="url">Request URL.</param>
        /// <param name="queryParams">Query string parameters.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        protected static string GetRawContent(string url, IQueryParams queryParams=null, IVcRestClient client = null)
        {
            client = client ?? VcClient.GetRestClient();
            Request request = new Request(Method.Get, url, queryParams);
            Response response = client.Request(request);

            return response.Content;
        }

        /// <summary>
        /// Executes an Update request.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">Request URL.</param>
        /// <param name="body">HTTP body.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        protected static T Update<T>(string url, IBody body, JsonConverter[] jsonConverters = null, IVcRestClient client = null) where T : IResourceEntity
        {
            return CreateOrUpdate<T>(Method.Put, url, body, jsonConverters, client);
        }

        /// <summary>
        /// Executes a Create request.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">Request URL.</param>
        /// <param name="body">HTTP body.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        protected static T Create<T>(string url, IBody body = null, JsonConverter[] jsonConverters = null, IVcRestClient client = null) where T : IResourceEntity
        {
            return CreateOrUpdate<T>(Method.Post, url, body, jsonConverters, client);
        }

        /// <summary>
        /// Executes a Create request with a raw response.
        /// </summary>
        /// <param name="url">Request URL.</param>
        /// <param name="body">HTTP body.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        protected static string CreateRawContent(string url, IBody body = null, IVcRestClient client = null)
        {
            return CreateOrUpdateRawContent(Method.Post, url, body, client);
        }

        /// <summary>
        /// Executes a Create or Update request.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="method">HTTP method.</param>
        /// <param name="url">Request URL.</param>
        /// <param name="body">HTTP body.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static T CreateOrUpdate<T>(string method, string url, IBody body, JsonConverter[] jsonConverters = null, IVcRestClient client = null) where T : IResourceEntity
        {
            client = client ?? VcClient.GetRestClient();
            Request request = new Request(method, url, body);
            Response response = client.Request(request);
            JObject json = JObject.Parse(response.Content);

            return JsonConvert.DeserializeObject<T>(json.First.First.ToString(), jsonConverters);
        }

        /// <summary>
        /// Executes a Create or Update request with a raw response.
        /// </summary>
        /// <param name="method">HTTP method.</param>
        /// <param name="url">Request URL.</param>
        /// <param name="body">HTTP body.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        private static string CreateOrUpdateRawContent(string method, string url, IBody body, IVcRestClient client = null)
        {
            client = client ?? VcClient.GetRestClient();
            Request request = new Request(method, url, body);
            Response response = client.Request(request);

            return response.Content;
        }

        /// <summary>
        /// Executes a Delete request.
        /// </summary>
        /// <param name="url">Request URL.</param>
        /// <param name="client">REST client.</param>
        /// <returns></returns>
        protected static bool Delete(string url, IVcRestClient client = null)
        {
            client = client ?? VcClient.GetRestClient();
            Request request = new Request(Method.Delete, url);
            Response response = client.Request(request);

            return response.StatusCode == HttpStatusCode.NoContent;
        }
    }
}
