namespace NOpenMessaging.Interceptors
{

    /**
     * A {@code Context} is used to transfer user's business data in the interceptor.
     *
     * @version OMS 1.0.0
     * @since OMS 1.0.0
     */
    public interface IContext
    {

        /**
         * Returns the attributes of this {@code Context} instance.
         *
         * @return the attributes.
         */
        IKeyValue attributes();
    }
}