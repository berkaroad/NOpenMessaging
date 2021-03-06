using NOpenMessaging.Messaging;

namespace NOpenMessaging.Producing
{
    /**
     * Each executor will be associated with a transactional message, can be used to execute local transaction branch and
     * submit the transaction status(commit or rollback).
     * <p>
     *
     * The associated message will be exposed to consumer when the local transaction has been committed, or be discarded if
     * local transaction has been rolled back.
     *
     * <p>
     * If the executor doesn't submit the transaction status for a long time, the server may lookup it forwardly through
     * {@link TransactionStateCheckListener#check(Message, TransactionalContext)}
     *
     * @version OMS 1.0.0
     * @since OMS 1.0.0
     */
    public interface ITransactionStateCheckListener
    {
        /**
         * Checks the status of the local transaction branch.
         *
         * @param message the associated message.
         * @param context the check context.
         */
        void check(IMessage message, ITransactionalContext context);
    }
}