
namespace VivialConnect.Exceptions
{
    /// <summary>
    /// Class that represents an Authentication exception
    /// </summary>
    /// <seealso cref="VivialConnect.Exceptions.VcException" />
    class AuthenticationException : VcException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public AuthenticationException(string message) : base(message) { }
    }
}
