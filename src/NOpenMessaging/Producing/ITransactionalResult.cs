namespace NOpenMessaging.Producing
{
    /**
     * The result of sending a OMS prepare message to server with the message id, this result can be used to commits or or
     * rolls back a prepare message.
     *
     * @version OMS 1.0.0
     * @since OMS 1.0.0
     */
    public interface ITransactionalResult : ISendResult
    {
        /**
         * The unique transactionId id related to the {@code TransactionResult} instance.
         *
         * @return the transactional id
         */
        string transactionId();

        /**
         * Commits a transaction.
         */
        void commit();

        /**
         * Rolls back a transaction.
         */
        void rollback();
    }
}