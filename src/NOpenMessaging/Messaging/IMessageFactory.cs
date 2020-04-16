using NOpenMessaging.Exceptions;

namespace NOpenMessaging.Messaging
{
    /**
     * A factory interface for creating {@code Message} objects.
     *
     * @version OMS 1.0.0
     * @since OMS 1.0.0
     */
    public interface IMessageFactory
    {
        /**
         * Creates a {@code Message} object. A {@code Message} object is used to send a message containing a stream of
         * uninterpreted bytes.
         * <p>
         * The returned {@code Message} object only can be sent to the specified queue.
         *
         * @param queueName the target queue to send
         * @param body the body data for a message
         * @return the created {@code Message} object
         * @throws OMSMessageFormatException when body exceed the maximum length or others.
         */
        IMessage createMessage(string queueName, byte[] body);
    }
}