namespace NOpenMessaging
{
    /// <summary>
    /// A collection of all service states.
    /// </summary>
    public enum ServiceLifeState
    {
        /// <summary>
        /// Service has been initialized.
        /// </summary>
        INITIALIZED,

        /// <summary>
        /// Service in starting.
        /// </summary>
        STARTING,

        /// <summary>
        /// Service in running.
        /// </summary>
        STARTED,

        /// <summary>
        /// Service in stopping.
        /// </summary>
        STOPPING,

        /// <summary>
        /// Service has been stopped.
        /// </summary>
        STOPPED,
    }
}