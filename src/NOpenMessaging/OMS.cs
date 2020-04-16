using NOpenMessaging.Internals;

namespace NOpenMessaging
{
    /// <summary>
    /// The oms class provides some static methods to create a <see cref="IMessagingAccessPoint" /> from the specified OMS driver url
    /// and some useful util methods.
    /// </summary>
    /// <remarks>
    /// The complete OMS driver URL syntax is:
    /// <![CDATA[
    /// oms:<driver_type>://[account_id@]host1[:port1][,host2[:port2],...[,hostN[:portN]]]/<region>
    /// ]]>
    /// The first part of the URL specifies which OMS implementation is to be used, rocketmq is a optional driver type.
    /// The brackets indicate that the extra access points are optional, and a correct OMS driver url needs at least one
    /// access point, which consists of hostname and port, like localhost:8081.
    /// </remarks>
    public sealed class OMS
    {
        /**
         * Returns a {@code MessagingAccessPoint} instance from the specified OMS driver url.
         *
         * @param url the specified OMS driver url
         * @return a {@code MessagingAccessPoint} instance
         * @throws OMSRuntimeException if the factory fails to create a {@code MessagingAccessPoint} due to some driver url
         * some syntax error or internal error.
         */
        public static IMessagingAccessPoint getMessagingAccessPoint(string url)
        {
            return getMessagingAccessPoint(url, OMS.newKeyValue());
        }

        /**
         * Returns a {@code MessagingAccessPoint} instance from the specified OMS driver url with some preset attributes,
         * which will be passed to MessagingAccessPoint's implementation class as a unique constructor parameter.
         *
         * There are some standard attributes defined by OMS for this method, the same as {@link
         * MessagingAccessPoint#attributes()} ()}
         *
         * @param url the specified OMS driver url
         * @return a {@code MessagingAccessPoint} instance
         * @throws OMSRuntimeException if the factory fails to create a {@code MessagingAccessPoint} due to some driver url
         * some syntax error or internal error.
         */
        public static IMessagingAccessPoint getMessagingAccessPoint(string url, IKeyValue attributes)
        {
            return MessagingAccessPointAdapter.getMessagingAccessPoint(url, attributes);
        }

        /**
         * Returns a default and internal {@code KeyValue} implementation instance.
         *
         * @return a {@code KeyValue} instance
         */
        public static IKeyValue newKeyValue()
        {
            return new DefaultKeyValue();
        }

        /// <summary>
        /// The version format is X.Y.Z (Major.Minor.Patch)
        /// OMS version follows semver scheme partially.
        /// </summary>
        public static string specVersion = "Unknown";

        static OMS()
        {
            var ver = typeof(OMS).Assembly.GetName().Version;
            specVersion = $"{ver.Major}.{ver.Minor}.{ver.Build}";
        }

        private OMS()
        {
        }
    }
}