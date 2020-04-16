namespace NOpenMessaging.Consuming
{
    /// <summary>
    /// IMessageListener Context
    /// </summary>
    public interface IMessageListenerContext
    {
        /**
         * Acknowledges the specified and consumed message, which is related to this {@code MessageContext}.
         * <p>
         * Messages that have been received but not acknowledged may be redelivered.
         *
         * @throws OMSRuntimeException if the consumer fails to acknowledge the messages due to some internal error.
         */
        void ack();
    }
}