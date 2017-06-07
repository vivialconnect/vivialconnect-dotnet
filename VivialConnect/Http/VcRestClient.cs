using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using VivialConnect.Crypto;
using VivialConnect.Exceptions;

namespace VivialConnect.Http
{
    /// <summary>
    /// Implemenation of the VCRestClient.
    /// </summary>
    public class VcRestClient : IVcRestClient
    {
        public const string ApiContentType = "application/json, text/javascript";
        public readonly string[] ApiHmacSignedHeaders = { "content-type", "date", "host" };

        private string _apiKey;
        private string _apiSecret;
        private string _apiBaseUrl;
        private RestClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="VcRestClient"/> class.
        /// </summary>
        /// <param name="apiKey">API key.</param>
        /// <param name="apiSecret">API secret.</param>
        /// <param name="apiBaseUrl">API base URL.</param>
        public VcRestClient(string apiKey, string apiSecret, string apiBaseUrl)
        {
            _apiKey = apiKey;
            _apiSecret = apiSecret;
            _apiBaseUrl = apiBaseUrl;
            _client = new RestClient(_apiBaseUrl);
            _client.UserAgent = string.Format("VivialConnect DotNetClient {0}", Utils.GetVersion());
        }

        /// <summary>
        /// Process request.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <returns></returns>
        public Response Request(Request request)
        {
            Response response = RequestRaw(request);
            return ProcessResponse(response);
        }

        /// <summary>
        /// Processes the raw request.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <returns></returns>
        private Response RequestRaw(Request request)
        {
            DateTimeOffset now = DateTimeOffset.UtcNow;
            string apiUrl = BuildApiUrl(request.Url);
            Uri parsedUrl = new Uri(apiUrl);

            List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>();
            headers.Add(new KeyValuePair<string, string>("X-VivialConnect-User-Agent", GetVcUserAgent()));
            headers.Add(new KeyValuePair<string, string>("User-Agent", _client.UserAgent));
            headers.Add(new KeyValuePair<string, string>("Date", now.ToString("ddd, dd MMM yyyy HH:mm:ss 'GMT'")));
            headers.Add(new KeyValuePair<string, string>("Host", parsedUrl.Host));
            headers.Add(new KeyValuePair<string, string>("Accept", ApiContentType));

            if (request.HasBody)
            {
                headers.Add(new KeyValuePair<string, string>("Content-Type", ApiContentType));
            }
            else
            {
                if (Method.IsPostOrPut(request.Method))
                {
                    headers.Add(new KeyValuePair<string, string>("Content-Type", ApiContentType));
                    headers.Add(new KeyValuePair<string, string>("Content-Length", "0"));
                }
            }

            string iso8601TimeStamp = now.ToString(Utils.Iso8601DateFormat);
            string jsonBody = Hash.EncodeString(request.GetBodyAsJson());

            SignResult signResults = Sign(request.Method, iso8601TimeStamp, apiUrl, headers, request.GetQueryParamsList(), jsonBody);

            headers.Add(new KeyValuePair<string, string>("X-Auth-SignedHeaders", string.Join(";", signResults.UsedHeaders.ToArray())));
            headers.Add(new KeyValuePair<string, string>("X-Auth-Date", iso8601TimeStamp));
            headers.Add(new KeyValuePair<string, string>("Authorization", string.Format("HMAC {0}:{1}", _apiKey, signResults.Digest)));

            RestRequest restRequest = new RestRequest(request.Url, Utils.ParseEnum<RestSharp.Method>(request.Method));

            foreach (KeyValuePair<string, string> header in headers)
            {
                restRequest.AddHeader(header.Key, header.Value);
            }

            foreach(KeyValuePair<string, string> kvp in request.GetQueryParamsList())
            {
                restRequest.AddQueryParameter(kvp.Key, kvp.Value);
            }

            if(request.HasBody)
            {
                restRequest.AddParameter(ApiContentType, jsonBody, ParameterType.RequestBody);
            }

            IRestResponse restResponse = _client.Execute(restRequest);

            return new Response(restResponse.StatusCode,
                                restResponse.Content,
                                restResponse.ContentEncoding,
                                restResponse.ContentLength,
                                restResponse.ContentType,
                                restResponse.ErrorException,
                                restResponse.ErrorMessage,
                                restResponse.RawBytes,
                                restResponse.ResponseStatus.ToString(),
                                restResponse.ResponseUri);
        }

        /// <summary>
        /// Signs the request.
        /// </summary>
        /// <param name="method">HTTP method.</param>
        /// <param name="iso8601TimeStamp">ISO8601 time stamp.</param>
        /// <param name="url">Request URL.</param>
        /// <param name="headers">HTTP headers.</param>
        /// <param name="queryParams">Query string parameters.</param>
        /// <param name="jsonBody">JSON body.</param>
        /// <returns></returns>
        private SignResult Sign(string method, 
                                string iso8601TimeStamp, 
                                string url, 
                                List<KeyValuePair<string, string>> headers,
                                List<KeyValuePair<string, string>> queryParams,
                                string jsonBody)
        {
            List<string> apiHmacUsedSignedHeaders = new List<string>();
            List<string> canonicalHeaders = new List<string>();

            foreach (KeyValuePair<string, string> kvp in headers)
            {
                string lowerkey = kvp.Key.ToLower();
                if (!ApiHmacSignedHeaders.Contains(lowerkey))
                {
                    continue;
                }
                canonicalHeaders.Add(string.Format("{0}:{1}", lowerkey, kvp.Value));
                apiHmacUsedSignedHeaders.Add(lowerkey);
            }
            apiHmacUsedSignedHeaders.Sort();
            canonicalHeaders.Sort();

            Uri parsedUrl = new Uri(url);
            List<string> canonicalQueryString = new List<string>();
                        
            foreach(KeyValuePair<string, string> kvp in queryParams)
            {
                canonicalQueryString.Add(string.Format("{0}={1}", Uri.EscapeDataString(kvp.Key), Uri.EscapeDataString(kvp.Value)));
            }            
            canonicalQueryString.Sort();            

            string canonicalRequest = string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}", 
                                                        method.ToUpper(),
                                                        iso8601TimeStamp,
                                                        parsedUrl.AbsolutePath,
                                                        string.Join("&", canonicalQueryString.ToArray()) + string.Empty,
                                                        string.Join("\n", canonicalHeaders.ToArray()),
                                                        string.Join(";", apiHmacUsedSignedHeaders.ToArray()),
                                                        Hash.GetHashShaHex(jsonBody));

            string signedData = Hash.GetHashHmacHex(_apiSecret, canonicalRequest);

            return new SignResult { Digest = signedData, UsedHeaders = apiHmacUsedSignedHeaders };
        }

        /// <summary>
        /// Builds the API URL.
        /// </summary>
        /// <param name="url">Request URL.</param>
        /// <returns></returns>
        private string BuildApiUrl(string url)
        {
            string baseUrl = _apiBaseUrl;
            string pathUrl = url;

            if(baseUrl.EndsWith("/"))
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }

            if(url.StartsWith("/"))
            {
                pathUrl = url.Substring(1, url.Length - 1);
            }

            return string.Format("{0}/{1}", baseUrl, pathUrl);
        }

        /// <summary>
        /// The VivialConnect user agent.
        /// </summary>
        /// <returns></returns>
        private string GetVcUserAgent()
        {
            Dictionary<string, string> vcUserAgent = new Dictionary<string, string>();
            vcUserAgent.Add("client_version", Utils.GetVersion());
            vcUserAgent.Add("lang", "C#");
            vcUserAgent.Add("publisher", "vivialconnect");
            vcUserAgent.Add("request_lib", "requests");
            vcUserAgent.Add("clr_version", Environment.Version.ToString());
            vcUserAgent.Add("platform", Environment.OSVersion.ToString());
            vcUserAgent.Add("machine", Environment.MachineName.ToString());

            return JsonConvert.SerializeObject(vcUserAgent, Formatting.None);           
        }

        /// <summary>
        /// Processes the response.
        /// </summary>
        /// <param name="response">Response.</param>
        /// <returns></returns>
        /// <exception cref="ApiException"></exception>
        private static Response ProcessResponse(Response response)
        {
            if (response.StatusCode >= HttpStatusCode.OK && response.StatusCode < HttpStatusCode.Ambiguous)
            {
                return response;
            }

            throw new ApiException((int)response.StatusCode, response.ErrorMessage != null ? response.ErrorMessage : response.Content, response.ErrorException);
        }
    }
}
