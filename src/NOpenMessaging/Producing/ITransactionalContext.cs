namespace NOpenMessaging.Producing
{
    public interface ITransactionalContext
    {
        /**
         * Commits a transaction.
         */
        void commit();

        /**
         * Rolls back a transaction.
         */
        void rollback();

        /**
         * Unknown transaction status, may be this transaction still on going.
         */
        void unknown();
    }
}