using System;

namespace NOpenMessaging.Exceptions
{
    /// <summary>
    /// The client have no enough authority to operate an resource.
    /// </summary>
    public class OMSSecurityException : OMSRuntimeException
    {
        /// <summary>
        /// Constructs with the specified detail message and error code.
        /// </summary>
        /// <param name="errorCode">a specified error code</param>
        /// <param name="message">a description of the exception</param>
        public OMSSecurityException(int errorCode, string message)
        : base(errorCode, message) { }

        /// <summary>
        /// Constructs with the specified error code and cause.
        /// </summary>
        /// <param name="errorCode">a specified error code</param>
        /// <param name="cause">the underlying cause of this exception</param>
        public OMSSecurityException(int errorCode, Exception innerException)
            : base(errorCode, innerException) { }

        /// <summary>
        /// Constructs with the specified detail message, error code and cause.
        /// </summary>
        /// <param name="errorCode">a specified error code</param>
        /// <param name="message"><a description of the exception/param>
        /// <param name="innerException">the underlying cause of this exception</param>
        public OMSSecurityException(int errorCode, String message, Exception innerException)
            : base(errorCode, message, innerException) { }
    }
}