namespace NOpenMessaging
{
    /// <summary>
    /// This is the centralized source for keys that are used for OMS standard attributes.
    /// </summary>
    public sealed class OMSBuiltinKeys
    {
        /**
         * The {@code DRIVER_IMPL} key represents the vendor implementation
         * entry of {@link MessagingAccessPoint}.
         */
        public const string DRIVER_IMPL = "DRIVER_IMPL";

        /**
         * The {@code ACCESS_POINTS} key shows the specified access points in OMS driver schema.
         * @see <a href="https://github.com/openmessaging/specification/blob/master/oms_access_point_schema.md">Access Point Schema</a>
         */
        public const string ACCESS_POINTS = "ACCESS_POINTS";

        /**
         * The {@code ACCOUNT_ID} key shows the specified account info in OMS driver schema.
         */
        public const string ACCOUNT_ID = "ACCOUNT_ID";

        /**
         * The {@code ACCOUNT_KEY} key shows the specified account key in OMS attribute.
         */
        public const string ACCOUNT_KEY = "ACCOUNT_KEY";

        /**
         * The {@code REGION} key shows the specified region in OMS driver schema.
         */
        public const string REGION = "REGION";
    }
}