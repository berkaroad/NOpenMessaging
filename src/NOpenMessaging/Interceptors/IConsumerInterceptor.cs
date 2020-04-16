using NOpenMessaging.Messaging;

namespace NOpenMessaging.Interceptors
{
    /**
     * A {@code ConsumerInterceptor} is used to intercept consume operations of push consumer.
     *
     * @version OMS 1.0.0
     * @since OMS 1.0.0
     */
    public interface IConsumerInterceptor
    {
        /**
         * Invoked before the invocation of {@link MessageListener#onReceived(Message, MessageListener.Context)}.
         *
         * @param message the message is actually received.
         * @param attributes the extensible attributes delivered to the intercept thread.
         */
        void preReceive(IMessage message, IContext attributes);

        /**
         * Invoked after the invocation of {@link MessageListener#onReceived(Message, MessageListener.Context)}.
         *
         * @param message the message is actually received.
         * @param attributes the extensible attributes delivered to the intercept thread.
         */
        void postReceive(IMessage message, IContext attributes);
    }
}