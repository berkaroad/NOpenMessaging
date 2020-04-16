namespace NOpenMessaging.Consuming
{
    /// <summary>
    /// IBatchMessageListener Context
    /// </summary>
    public interface IBatchMessageListenerContext
    {
        /// <summary>
        /// Acknowledges the specified and consumed message, which is related to this MessageContext }.
        /// <exception cref="OMSRuntimeException" />if the consumer fails to acknowledge the messages due to some internal error.
        /// </summary>
        /// <param name="messages"></param>
        void success(params IMessageReceipt[] messages);

        /// <summary>
        /// Acknowledges all messages in this batch, which is related to this MessageContext}.
        /// <excetion cref="OMSRuntimeException" />if the consumer fails to acknowledge the messages due to some internal error.
        /// </summary>
        void ack();
    }
}