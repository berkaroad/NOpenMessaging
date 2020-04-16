using NOpenMessaging.Attributes;
using NOpenMessaging.Exceptions;
using System.Collections.Generic;

namespace NOpenMessaging.Extensions
{
    /// <summary>
    /// Used for getting configurations related implementation. but this interface are not mandatory.
    /// </summary>
    [Optional]
    public interface IExtension
    {
        /// <summary>
        /// Getting the related queue's meta data, and this method is optional, vendors may not provide this method based on their implementation.
        /// </summary>
        /// <param name="queueName">Queue name, message destination.</param>
        /// <exception cref="OMSSecurityException"/>when have no authority to send messages to a given destination.
        /// <exception cref="OMSTimeOutException"/>when the given timeout elapses before the send operation completes.
        /// <exception cref="OMSDestinationException"/>when have no given destination in the server.
        /// <exception cref="OMSRuntimeException"/>when the <see cref="Producer"/> fails to send the message due to some internal error.
        /// <returns><see cref="IQueueMetaData"/></returns>
        ISet<IQueueMetaData> getQueueMetaData(string queueName);
    }
}