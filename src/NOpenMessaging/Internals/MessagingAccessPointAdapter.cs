using System;

namespace NOpenMessaging.Internals
{
    /**
     * The {@code MessagingAccessPointAdapter} provides a common implementation to create a specified {@code
     * MessagingAccessPoint} instance, used by OMS internally.
     *
     * @version OMS 1.0.0
     * @since OMS 1.0.0
     */
    internal class MessagingAccessPointAdapter
    {
        /**
         * Returns a {@code MessagingAccessPoint} instance from the specified OMS driver URL with some preset userHeaders.
         *
         * @param url the driver URL.
         * @param attributes the preset userHeaders.
         * @return a {@code MessagingAccessPoint} instance.
         * @throws OMSRuntimeException if the adapter fails to create a {@code MessagingAccessPoint} instance from the URL.
         */
        public static IMessagingAccessPoint getMessagingAccessPoint(string url, IKeyValue attributes)
        {
            AccessPointURI accessPointURI = new AccessPointURI(url);
            string driverImpl = parseDriverImpl(accessPointURI.getDriverType(), attributes);

            attributes.put(OMSBuiltinKeys.ACCESS_POINTS, accessPointURI.getHosts());
            attributes.put(OMSBuiltinKeys.DRIVER_IMPL, driverImpl);
            attributes.put(OMSBuiltinKeys.REGION, accessPointURI.getRegion());
            attributes.put(OMSBuiltinKeys.ACCOUNT_ID, accessPointURI.getAccountId());

            try
            {
                var driverImplClass = Type.GetType(driverImpl);
                var constructor = driverImplClass.GetConstructor(new Type[] { typeof(IKeyValue) });
                IMessagingAccessPoint vendorImpl = (IMessagingAccessPoint)constructor.Invoke(new object[] { attributes });
                checkSpecVersion(OMS.specVersion, vendorImpl.version());
                return vendorImpl;
            }
            catch
            {
                throw OMSResponseStatus.generateException(OMSResponseStatus.STATUS_10000, url);
            }
        }

        private static string parseDriverImpl(string driverType, IKeyValue attributes)
        {
            if (attributes.containsKey(OMSBuiltinKeys.DRIVER_IMPL))
            {
                return attributes.getString(OMSBuiltinKeys.DRIVER_IMPL);
            }
            return "NOpenMessaging." + driverType + ".MessagingAccessPointImpl";
        }

        private static void checkSpecVersion(string specVersion, string implVersion)
        {
            string majorVerOfImpl;
            string majorVerOfSpec = specVersion.Substring(0, specVersion.IndexOf('.', specVersion.IndexOf('.') + 1));
            try
            {
                majorVerOfImpl = implVersion.Substring(0, implVersion.IndexOf('.', implVersion.IndexOf('.') + 1));
            }
            catch
            {
                throw OMSResponseStatus.generateException(OMSResponseStatus.STATUS_10002, implVersion);
            }
            if (!majorVerOfSpec.Equals(majorVerOfImpl))
            {
                throw OMSResponseStatus.generateException(OMSResponseStatus.STATUS_10003, implVersion, specVersion);
            }
        }
    }
}