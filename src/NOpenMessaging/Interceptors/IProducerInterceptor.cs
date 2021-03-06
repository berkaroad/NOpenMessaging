using NOpenMessaging.Messaging;

namespace NOpenMessaging.Interceptors
{
    /**
     * A {@code ProducerInterceptor} is used to intercept send operations of producer.
     * <p>
     * The interceptor is able to view or modify the message being transmitted and collect the send record.
     *
     * @version OMS 1.0.0
     * @since OMS 1.0.0
     */
    public interface IProducerInterceptor
    {
        /**
         * Invoked before the message is actually sent to the network.
         * <p>
         * This allows for modification of the message if necessary.
         *
         * @param message a message will be sent.
         * @param attributes the extensible attributes delivered to the intercept thread.
         */
        void preSend(IMessage message, IContext attributes);

        /**
         * Invoked immediately after the successful send invocation.
         *
         * @param message the message is actually sent.
         * @param attributes the extensible attributes delivered to the intercept thread.
         */
        void postSend(IMessage message, IContext attributes);

    }
}