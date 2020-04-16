using System;

namespace NOpenMessaging.Exceptions
{
    /// <summary>
    /// This is the root class of all unchecked exceptions in the OMS API.
    /// </summary>
    /// <remarks>
    /// A OMSException consists of the following parts:
    /// <ul>
    /// * <li>A provider-specific string describing the error.</li>
    /// * <li>A provider-specific string error code to identify the specific exception type.</li>
    /// * </ul>
    /// </remarks>
    public class OMSRuntimeException : ApplicationException
    {
        /// <summary>
        /// Constructs with the specified detail message and error code.
        /// </summary>
        /// <param name="errorCode">a specified error code</param>
        /// <param name="message">a description of the exception</param>
        public OMSRuntimeException(int errorCode, String message)
            : base(message)
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        /// Constructs with the specified error code and cause.
        /// </summary>
        /// <param name="errorCode">a specified error code</param>
        /// <param name="cause">the underlying cause of this exception</param>
        public OMSRuntimeException(int errorCode, Exception cause)
            : base(cause.Message, cause)
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        /// Constructs with the specified detail message, error code and cause.
        /// </summary>
        /// <param name="errorCode">a specified error code</param>
        /// <param name="message"><a description of the exception/param>
        /// <param name="innerException">the underlying cause of this exception</param>
        public OMSRuntimeException(int errorCode, String message, Exception innerException)
            : base(message, innerException)
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        /// Vendor-specific error code
        /// </summary>
        public int ErrorCode { get; private set; }
    }
}