using System;

namespace NOpenMessaging
{
    /// <summary>
    /// A <see cref="IFuture" /> represents the result of an asynchronous computation.  Methods are provided to check if the
    /// computation is complete, to wait for its completion, and to retrieve the result of the computation.  The result can
    /// only be retrieved using method {@code get} when the computation has completed, blocking if necessary until it is
    /// ready. Additional methods are provided to determine if the task completed normally or was cancelled.
    /// </summary>
    /// <typeparam name="V"></typeparam>
    public interface IFuture<V>
    {
        /// <summary>
        /// Attempts to cancel execution of this task.  This attempt will
        /// fail if the task has already completed, has already been cancelled,
        /// or could not be cancelled for some other reason. If successful,
        /// and this task has not started when {@code cancel} is called,
        /// this task should never run.  If the task has already started,
        /// then the {@code mayInterruptIfRunning} parameter determines
        /// whether the thread executing this task should be interrupted in
        /// an attempt to stop the task.
        /// </summary>
        /// <param name="mayInterruptIfRunning">true if the thread executing this task should be interrupted; otherwise, in-progress tasks are allowed to complete</param>
        /// <returns>{@code false} if the task could not be cancelled, typically because it has already completed normally; true otherwise</returns>
        bool cancel(bool mayInterruptIfRunning);

        /**
         * Returns {@code true} if this task was cancelled before it completed normally.
         *
         * @return {@code true} if this task was cancelled before it completed
         */
        /// <summary>
        /// Returns true if this task was cancelled before it completed normally.
        /// </summary>
        /// <returns></returns>
        bool isCancelled();

        /// <summary>
        /// Returns true if this task completed.
        /// </summary>
        /// <remarks>
        /// Completion may be due to normal termination, an exception, or cancellation -- in all of these cases, this method
        /// will return {@code true}.
        /// </remarks>
        /// <returns>true if this task completed</returns>
        bool isDone();

        /**
         * Waits if necessary for the computation to complete, and then retrieves its result.
         *
         * @return the computed result
         */
        V get();

        /**
         * Waits if necessary for at most the given time for the computation to complete, and then retrieves its result, if
         * available.
         *
         * @param timeout the maximum time to wait
         * @return the computed result <p> if the computation was cancelled
         */
        V get(long timeout);

        /**
         * Adds the specified listener to this future. The specified listener is notified when this future is done. If this
         * future is already completed, the specified listener will be notified immediately.
         *
         * @param listener FutureListener
         */
        void addListener(IFutureListener<V> listener);

        /**
         * Returns the cause of the failed future
         *
         * @return the cause of the failure. {@code null} if succeeded or this future is not completed yet.
         */
        Exception getThrowable();
    }
}