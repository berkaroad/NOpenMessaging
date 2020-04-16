namespace NOpenMessaging.Producing
{
    /**
     * The result of sending a OMS message to server with the message id and some attributes.
     *
     * @version OMS 1.0.0
     * @since OMS 1.0.0
     */
    public interface ISendResult
    {
        /**
         * The unique message id related to the {@code SendResult} instance.
         *
         * @return the message id.
         */
        string messageId();
    }
}