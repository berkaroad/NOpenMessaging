using NOpenMessaging.Extensions;

namespace NOpenMessaging
{

    /**
     * The {@code ServiceLifecycle} defines a lifecycle interface for a OMS related service endpoint, like {@link Producer},
     * {@link Consumer}, and so on.
     * <p>
     * If the service endpoint class implements the {@code ServiceLifecycle} interface, most of the containers can manage
     * the lifecycle of the corresponding service endpoint objects easily.
     * <p>
     * Any service endpoint should support repeated restart if it implements the {@code ServiceLifecycle} interface.
     *
     * @version OMS 1.0.0
     * @since OMS 1.0.0
     */
    public interface IServiceLifecycle : IExtension
    {
        /**
         * Used for startup or initialization of a service endpoint. A service endpoint instance will be in a ready state
         * after this method has been completed.
         */
        void start();

        /**
         * Notify a service instance of the end of its life cycle. Once this method completes, the service endpoint could be
         * destroyed and eligible for garbage collection.
         */
        void stop();

        /**
         * Used for get service current state, for execution of some operations is dependent on the current service state.
         *
         * @return This service current state {@link ServiceLifeState}
         */
        ServiceLifeState currentState();

    }
}