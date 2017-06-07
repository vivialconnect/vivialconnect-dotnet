using System;

namespace VivialConnect.Exceptions
{
    /// <summary>
    /// Class that represents an API exception.
    /// </summary>
    /// <seealso cref="VivialConnect.Exceptions.VcException" />
    public class ApiException : VcException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class.
        /// </summary>
        /// <param name="message">Error message.</param>
        public ApiException(string message) : base(message){ }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <param name="exception">Original exception.</param>
        public ApiException(string message, Exception exception) : base(message, exception) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class.
        /// </summary>
        /// <param name="status">HTTP status code.</param>
        /// <param name="message">Error message.</param>
        /// <param name="exception">Original exception.</param>
        public ApiException(int status, string message, Exception exception) : base(message, exception)
        {
            Status = status;
        }

        /// <summary>
        /// Gets the HTTP status code.
        /// </summary>
        /// <value>
        /// HTTP status code.
        /// </value>
        public int Status { get; }        
    }
}
