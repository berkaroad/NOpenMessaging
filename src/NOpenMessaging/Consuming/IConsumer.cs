using System.Collections.Generic;
using NOpenMessaging.Interceptors;

namespace NOpenMessaging.Consuming
{
    /// <summary>
    /// A <see cref="IPushConsumer"> receives messages from multiple queues,
    /// these messages are pushed from MOM server to <see cref="IConsumer" /> client.
    /// </summary>
    public interface IConsumer : IServiceLifecycle, IClient
    {

        /**
         * This method is used to find out the collection of queues bind to {@code Consumer}.
         *
         * @return the queues this consumer is bind, or null if the consumer is not bind queue.
         */
        ISet<string> getBindQueues();

        /**
         * Adds a {@code ConsumerInterceptor} instance to this consumer.
         *
         * @param interceptor an interceptor instance.
         */
        void addInterceptor(IConsumerInterceptor interceptor);

        /**
         * Removes an interceptor from this consumer.
         *
         * @param interceptor an interceptor to be removed.
         */
        void removeInterceptor(IConsumerInterceptor interceptor);

        /**
         * Acknowledges the specified and consumed message with the unique message receipt handle, in the scenario of using
         * manual commit.
         * <p>
         * Messages that have been received but not acknowledged may be redelivered.
         *
         * @param receipt the receipt handle associated with the consumed message.
         */
        void ack(IMessageReceipt receipt);

    }
}