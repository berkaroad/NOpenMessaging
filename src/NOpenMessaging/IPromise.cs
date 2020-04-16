using System;

namespace NOpenMessaging
{
    /**
     * Special {@link Future} which is writable.
     * <p>
     * A {@code Promise} can be completed or canceled, cancellation is performed by the {@code cancel} method.
     * Once a computation has completed, the computation cannot be cancelled. If you would like to use a {@code Promise}
     * for the sake of cancellability but not provide a usable result, you can declare type+s of the form
     * {@code Promise<?>} and return {@code null} as a result of the underlying task.
     *
     * @version OMS 1.0.0
     * @since OMS 1.0.0
     */
    public interface IPromise<V> : IFuture<V>
    {
        /**
         * Set the value to this promise and mark it completed if set successfully.
         *
         * @param value Value
         * @return Whether set is success
         */
        bool set(V value);

        /**
         * Marks this promise as a failure and notifies all listeners.
         *
         * @param cause the cause
         * @return Whether set is success
         */
        bool setFailure(Exception cause);
    }
}