using System.Collections.Generic;

namespace NOpenMessaging.Consuming
{
    /**
     * A {@code PushConsumer} receives messages from multiple queues, these messages are pushed from
     * MOM server to {@code PushConsumer} client.
     *
     * @version OMS 1.0.0
     * @see MessagingAccessPoint#createPushConsumer()
     * @since OMS 1.0.0
     */
    public interface IPushConsumer : IConsumer
    {
        /**
         * Resumes the {@code Consumer} in push model after a suspend.
         * <p>
         * This method resumes the {@code Consumer} instance after it was suspended. The instance will not receive new
         * messages between the suspend and resume calls.
         *
         * @throws OMSRuntimeException if the instance has not been suspended.
         * @see PushConsumer#suspend()
         */
        void resume();

        /**
         * Suspends the {@code Consumer} in push model for later resumption.
         * <p>
         * This method suspends the consumer until it is resumed. The consumer will not receive new messages between the
         * suspend and resume calls.
         * <p>
         * This method behaves exactly as if it simply performs the call {@code suspend(0)}.
         *
         * @throws OMSRuntimeException if the instance is not currently running.
         * @see PushConsumer#resume()
         */
        void suspend();

        /**
         * Suspends the {@code Consumer} in push model for later resumption.
         * <p>
         * This method suspends the consumer until it is resumed or a specified amount of time has elapsed. The consumer
         * will not receive new messages during the suspended state.
         * <p>
         * This method is similar to the {@link #suspend()} method, but it allows finer control over the amount of time to
         * suspend, and the consumer will be suspended until it is resumed if the timeout is zero.
         *
         * @param timeout the maximum time to suspend in milliseconds.
         * @throws OMSRuntimeException if the instance is not currently running.
         */
        void suspend(long timeout);

        /**
         * This method is used to find out whether the {@code Consumer} in push model is suspended.
         *
         * @return true if this {@code Consumer} is suspended, false otherwise.
         */
        bool isSuspended();

        /**
         * Bind the {@code Consumer} to a collection of queue, with a {@code MessageListener}.
         * <p>
         * {@link MessageListener#onReceived(Message, MessageListener.Context)} will be called when new delivered message is
         * coming.
         *
         * @param queueNames a collection of queues.
         * @param listener a specified listener to receive new message.
         * @throws OMSSecurityException when have no authority to bind to this queue.
         * @throws OMSDestinationException when have no given destination in the server.
         * @throws OMSRuntimeException when the {@code Producer} fails to send the message due to some internal error.
         */
        void bindQueue(ICollection<string> queueNames, IMessageListener listener);


        /**
         * Bind the {@code Consumer} to a collection of queue, with a {@code BatchMessageListener}.
         * <p>
         * {@link BatchMessageListener#onReceived(List, BatchMessageListener.Context)} will be called when new delivered
         * messages is coming.
         *
         * @param queueNames a collection of queues.
         * @param listener a specified listener to receive new messages.
         * @throws OMSSecurityException when have no authority to bind to this queue.
         * @throws OMSDestinationException when have no given destination in the server.
         * @throws OMSRuntimeException when the {@code Producer} fails to send the message due to some internal error.
         */
        void bindQueue(ICollection<string> queueNames, IBatchMessageListener listener);

        /**
         * Unbind the {@code Consumer} from a collection of queues.
         * <p>
         * After the success call, this consumer won't receive new message from the specified queue any more.
         *
         * @param queueNames a collection of queues.
         */
        void unbindQueue(ICollection<string> queueNames);

    }
}