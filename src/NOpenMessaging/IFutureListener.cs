namespace NOpenMessaging
{
    /// <summary>
    /// A listener that is called back when a Promise is done.
    /// </summary>
    /// <typeparam name="V"></typeparam>
    public interface IFutureListener<V>
    {
        /// <summary>
        /// Invoked when the operation completes, be the associated <see creef="Promise" /> successful or not.
        /// </summary>
        /// <param name="future">The associated promise facade</param>
        void operationComplete(IFuture<V> future);
    }
}