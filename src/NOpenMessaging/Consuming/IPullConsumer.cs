using System.Collections.Generic;
using NOpenMessaging.Attributes;
using NOpenMessaging.Extensions;
using NOpenMessaging.Messaging;

namespace NOpenMessaging.Consuming
{

    /**
     * A {@code PullConsumer} pulls messages from the specified queue, and supports submit the consume result by
     * acknowledgement.
     *
     * @version OMS 1.0.0
     * @see MessagingAccessPoint#createPullConsumer()
     * @since OMS 1.0.0
     */
    public interface IPullConsumer : IConsumer
    {

        /**
         * Bind the {@code Consumer} to a collection of queue in pull model, user can use {@link PullConsumer#receive(long)}
         * to get messages from a collection of queue.
         * <p>
         *
         * @param queueNames a collection of queues.
         * @throws OMSSecurityException when have no authority to bind to this queue.
         * @throws OMSDestinationException when have no given destination in the server.
         * @throws OMSRuntimeException when the {@code Producer} fails to send the message due to some internal error.
         */
        void bindQueue(ICollection<string> queueNames);

        /**
         * Unbind the {@code Consumer} from a collection of queues.
         * <p>
         * After the success call, this consumer won't receive new message from the specified queue any more.
         *
         * @param queueNames a collection of queues.
         */
        void unbindQueue(ICollection<string> queueNames);

        /**
         * Receives the next message from the attached queues of this consumer.
         * <p>
         * This call blocks indefinitely until a message is arrives, the timeout expires, or until this {@code PullConsumer}
         * is shut down.
         *
         * @return the next message received from the attached queues, or null if the consumer is concurrently shut down or
         * the timeout expires
         * @throws OMSRuntimeException if the consumer fails to pull the next message due to some internal error.
         */
        IMessage receive();

        /**
         * Receives the next message from the bind queues of this consumer in pull model.
         * <p>
         * This call blocks indefinitely until a message is arrives, the timeout expires, or until this {@code PullConsumer}
         * is shut down.
         *
         * @param timeout receive message will blocked at most <code>timeout</code> milliseconds.
         * @return the next message received from the bind queues, or null if the consumer is concurrently shut down.
         * @throws OMSSecurityException when have no authority to receive messages from this queue.
         * @throws OMSTimeOutException when the given timeout elapses before the send operation completes.
         * @throws OMSRuntimeException when the {@code Producer} fails to send the message due to some internal error.
         */
        IMessage receive(long timeout);

        /**
         * Receives the next message from the which bind queue,partition and receiptId of this consumer in pull model.
         * <p>
         * This call blocks indefinitely until a message is arrives, the timeout expires, or until this {@code PullConsumer}
         * is shut down.
         *
         * @param queueName receive message from which queueName in Message Queue.
         * @param queueMetaData receive message from which partition in Message Queue.
         * @param messageReceipt receive message from which receipt position in Message Queue.
         * @param timeout receive message will blocked at most <code>timeout</code> milliseconds.
         * @return the next message received from the bind queues, or null if the consumer is concurrently shut down.
         * @throws OMSSecurityException when have no authority to receive messages from this queue.
         * @throws OMSTimeOutException when the given timeout elapses before the send operation completes.
         * @throws OMSRuntimeException when the {@code Producer} fails to send the message due to some internal error.
         */
        [Optional]
        IMessage receive(string queueName, IQueueMetaData queueMetaData, IMessageReceipt messageReceipt, long timeout);

        /**
         * Receive message in asynchronous way. This call doesn't block user's thread, and user's message resolve logic
         * should implement in the {@link MessageListener}.
         * <p>
         *
         * @param timeout receive messages will blocked at most <code>timeout</code> milliseconds.
         * @return the next batch messages received from the bind queues, or null if the consumer is concurrently shut down.
         * @throws OMSSecurityException when have no authority to receive messages from this queue.
         * @throws OMSTimeOutException when the given timeout elapses before the send operation completes.
         * @throws OMSRuntimeException when the {@code Producer} fails to send the message due to some internal error.
         */
        IList<IMessage> batchReceive(long timeout);

        /**
         * Receive message in asynchronous way. This call doesn't block user's thread, and user's message resolve logic
         * should implement in the {@link MessageListener}.
         * <p>
         *
         * @param queueName receive message from which queueName in Message Queue.
         * @param queueMetaData receive message from which partition in Message Queue.
         * @param messageReceipt receive message from which receipt position in Message Queue.
         * @param timeout receive messages will blocked at most <code>timeout</code> milliseconds.
         * @return the next batch messages received from the bind queues, or null if the consumer is concurrently shut down.
         * @throws OMSSecurityException when have no authority to receive messages from this queue.
         * @throws OMSTimeOutException when the given timeout elapses before the send operation completes.
         * @throws OMSRuntimeException when the {@code Producer} fails to send the message due to some internal error.
         */
        [Optional]
        IList<IMessage> batchReceive(string queueName, IQueueMetaData queueMetaData, IMessageReceipt messageReceipt,
            long timeout);
    }
}