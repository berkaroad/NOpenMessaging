using System;

namespace NOpenMessaging.Exceptions
{
    /// <summary>
    /// The the provided message is not supported or the attributes are the wrong type.
    /// </summary>
    public class OMSMessageFormatException : OMSRuntimeException
    {
        /// <summary>
        /// Constructs with the specified detail message and error code.
        /// </summary>
        /// <param name="errorCode">a specified error code</param>
        /// <param name="message">a description of the exception</param>
        public OMSMessageFormatException(int errorCode, string message)
        : base(errorCode, message) { }

        /// <summary>
        /// Constructs with the specified error code and cause.
        /// </summary>
        /// <param name="errorCode">a specified error code</param>
        /// <param name="cause">the underlying cause of this exception</param>
        public OMSMessageFormatException(int errorCode, Exception innerException)
            : base(errorCode, innerException) { }

        /// <summary>
        /// Constructs with the specified detail message, error code and cause.
        /// </summary>
        /// <param name="errorCode">a specified error code</param>
        /// <param name="message"><a description of the exception/param>
        /// <param name="innerException">the underlying cause of this exception</param>
        public OMSMessageFormatException(int errorCode, String message, Exception innerException)
            : base(errorCode, message, innerException) { }
    }
}