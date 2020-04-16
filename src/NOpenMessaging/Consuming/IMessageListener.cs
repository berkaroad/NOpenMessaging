using NOpenMessaging.Messaging;

namespace NOpenMessaging.Consuming
{
    /// <summary>
    /// A message listener must implement this {@code MessageListener} interface and register itself to a consumer instance
    /// to asynchronously receive messages.
    /// </summary>
    public interface IMessageListener
    {
        /**
         * Callback method to receive incoming messages.
         * <p>
         * A message listener should handle different types of {@code Message}.
         *
         * @param message the received message object.
         * @param context the context delivered to the consume thread.
         */
        void onReceived(IMessage message, IMessageListenerContext context);
    }
}