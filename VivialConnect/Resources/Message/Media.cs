using System;

namespace VivialConnect.Resources.Message
{
    /// <summary>
    /// Media details.
    /// </summary>
    public class Media
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Media"/> class.
        /// </summary>
        /// <param name="content">Content.</param>
        /// <param name="contentEncoding">Content encoding.</param>
        /// <param name="contentLength">Length of the content.</param>
        /// <param name="rawBytes">Raw bytes.</param>
        /// <param name="uri">URI.</param>
        public Media(string content, string contentEncoding, long contentLength, byte[] rawBytes, Uri uri)
        {
            Content = content;
            ContentEncoding = contentEncoding;
            ContentLength = contentLength;
            RawBytes = rawBytes;
            Uri = uri;
        }

        /// <summary>
        /// The content as a string representation.
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
        /// The raw bytes.
        /// </summary>
        /// <value>
        /// Raw bytes.
        /// </value>
        public byte[] RawBytes { get; }

        /// <summary>
        /// The URI of the media.
        /// </summary>
        /// <value>
        /// URI.
        /// </value>
        public Uri Uri { get; }
    }
}
