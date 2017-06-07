using System;
using System.Net;

namespace VivialConnect.Http
{
    /// <summary>
    /// VivialConnect response class.
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Response"/> class.
        /// </summary>
        /// <param name="statusCode">HTTP status code.</param>
        /// <param name="content">Content.</param>
        public Response(HttpStatusCode statusCode, string content)
        {
            StatusCode = statusCode;
            Content = content;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Response"/> class.
        /// </summary>
        /// <param name="statusCode">HTTP status code.</param>
        /// <param name="content">Content.</param>
        /// <param name="contentEncoding">Content encoding.</param>
        /// <param name="contentLength">Length of the content.</param>
        /// <param name="contentType">Type of the content.</param>
        /// <param name="errorException">Error exception.</param>
        /// <param name="errorMessage">Error message.</param>
        /// <param name="rawBytes">Raw bytes.</param>
        /// <param name="responseStatus">Response status.</param>
        /// <param name="responseUri">Response URI.</param>
        public Response (HttpStatusCode statusCode,
                        string content,
                        string contentEncoding,
                        long contentLength,
                        string contentType,
                        Exception errorException,
                        string errorMessage,
                        byte[] rawBytes,
                        string responseStatus,
                        Uri responseUri)
        {
            StatusCode = statusCode;
            Content = content;
            ContentEncoding = contentEncoding;
            ContentLength = contentLength;
            ContentType = contentType;
            ErrorException = errorException;
            ErrorMessage = errorMessage;
            RawBytes = rawBytes;
            ResponseUri = responseUri;
        }

        /// <summary>
        /// The HTTP status code.
        /// </summary>
        /// <value>
        /// Status code.
        /// </value>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// The content.
        /// </summary>
        /// <value>
        /// Content.
        /// </value>
        public string Content { get; }

        /// <summary>
        /// The content encoding.
        /// </summary>
        /// <value>
        /// Content encoding.
        /// </value>
        public string ContentEncoding { get; }

        /// <summary>
        /// The length of the content.
        /// </summary>
        /// <value>
        /// Length of the content.
        /// </value>
        public long ContentLength { get; }

        /// <summary>
        /// The type of the content.
        /// </summary>
        /// <value>
        /// Type of content.
        /// </value>
        public string ContentType { get; }

        /// <summary>
        /// The error exception.
        /// </summary>
        /// <value>
        /// Error exception.
        /// </value>
        public Exception ErrorException { get; }

        /// <summary>
        /// The error message.
        /// </summary>
        /// <value>
        /// Error message.
        /// </value>
        public string ErrorMessage { get; }

        /// <summary>
        /// The raw bytes.
        /// </summary>
        /// <value>
        /// Raw bytes.
        /// </value>
        public byte[] RawBytes { get; }

        /// <summary>
        /// The response status.
        /// </summary>
        /// <value>
        /// Response status.
        /// </value>
        public string ResponseStatus { get; }

        /// <summary>
        /// The response URI.
        /// </summary>
        /// <value>
        /// Response URI.
        /// </value>
        public Uri ResponseUri { get; }
    }
}
