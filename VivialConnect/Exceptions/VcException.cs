using System;

namespace VivialConnect.Exceptions
{
    /// <summary>
    /// Base VcException
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class VcException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VcException"/> class.
        /// </summary>
        public VcException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="VcException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public VcException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="VcException"/> class.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <param name="exception">Original exception.</param>
        public VcException(string message, Exception exception) : base(message, exception) { }
    }
}
