using System.Collections.Generic;
using NOpenMessaging.Messaging;

namespace NOpenMessaging.Consuming
{
    /// <summary>
    /// A message listener can implement this <see cref="IBatchMessageListener"> interface and register itself to a consumer
    /// instance to asynchronously receive messages.
    /// </summary>
    public interface IBatchMessageListener
    {
        /// <summary>
        /// Callback method to receive incoming messages.
        /// </summary>
        /// <param name="batchMessage">the received batchMessage.</param>
        /// <param name="context"></param>
        /// <remarks>A message listener should handle different types of BatchMessage.</remarks>
        void onReceived(IList<IMessage> batchMessage, IBatchMessageListenerContext context);
    }
}