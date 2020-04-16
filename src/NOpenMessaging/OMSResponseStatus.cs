using NOpenMessaging.Exceptions;

namespace NOpenMessaging
{
    /// <summary>
    /// This class defined OpenMessaging response status code
    /// </summary>
    public sealed class OMSResponseStatus
    {
        public static OMSResponseStatus STATUS_1101 = new OMSResponseStatus(1101, "Unsupported Version");

        public static OMSResponseStatus STATUS_1200 = new OMSResponseStatus(1200, "Success");

        public static OMSResponseStatus STATUS_1400 = new OMSResponseStatus(1400, "Bad Request");

        public static OMSResponseStatus STATUS_1401 = new OMSResponseStatus(1401, "Unauthorized");

        public static OMSResponseStatus STATUS_1402 = new OMSResponseStatus(1402, "Message body Required");

        public static OMSResponseStatus STATUS_1403 = new OMSResponseStatus(1403, "Forbidden");

        public static OMSResponseStatus STATUS_1404 = new OMSResponseStatus(1404, "Destination Not Found");

        public static OMSResponseStatus STATUS_1405 = new OMSResponseStatus(1405, "Namespace Not Found");

        public static OMSResponseStatus STATUS_1406 = new OMSResponseStatus(1406, "Destination Already Exists");

        public static OMSResponseStatus STATUS_1407 = new OMSResponseStatus(1407, "Namespace Already Exists");

        public static OMSResponseStatus STATUS_1408 = new OMSResponseStatus(1408, "ConsumerId Already Exists");

        public static OMSResponseStatus STATUS_1409 = new OMSResponseStatus(1409, "ProducerId Already Exists");

        public static OMSResponseStatus STATUS_1410 = new OMSResponseStatus(1410, "Request Timeout");

        public static OMSResponseStatus STATUS_1411 = new OMSResponseStatus(1411, "Message Attributes Too Large");

        public static OMSResponseStatus STATUS_1412 = new OMSResponseStatus(1412, "Message Header Too Large");

        public static OMSResponseStatus STATUS_1413 = new OMSResponseStatus(1413, "Message Body Too Large");

        public static OMSResponseStatus STATUS_1414 = new OMSResponseStatus(1414, "No New Message Found");

        public static OMSResponseStatus STATUS_1415 = new OMSResponseStatus(1415, "Max Topics Reached");

        public static OMSResponseStatus STATUS_1416 = new OMSResponseStatus(1416, "Max Queues Reached");

        public static OMSResponseStatus STATUS_1417 = new OMSResponseStatus(1417, "Max Namespaces Reached");

        public static OMSResponseStatus STATUS_1418 = new OMSResponseStatus(1418, "Bad Parameter");

        public static OMSResponseStatus STATUS_1500 = new OMSResponseStatus(1500, "Server STATUS");

        public static OMSResponseStatus STATUS_1501 = new OMSResponseStatus(1501, "Storage Service STATUS");

        public static OMSResponseStatus STATUS_1502 = new OMSResponseStatus(1502, "Storage Service Busy");

        public static OMSResponseStatus STATUS_1503 = new OMSResponseStatus(1503, "Service Not Available");

        public static OMSResponseStatus STATUS_1504 = new OMSResponseStatus(1504, "Flush Disk Timeout");

        public static OMSResponseStatus STATUS_10000 = new OMSResponseStatus(10000, "Can't construct a MessagingAccessPoint instance from the given OMS driver URL {0}.");

        public static OMSResponseStatus STATUS_10001 = new OMSResponseStatus(10001, "The OMS driver URL {0} is illegal.");

        public static OMSResponseStatus STATUS_10002 = new OMSResponseStatus(10002, "The implementation version {0} is illegal.");

        public static OMSResponseStatus STATUS_10003 = new OMSResponseStatus(10003, "The implementation version {0} isn't compatible with the specification version {1}.");

        private int statusCode;

        private string reasonPhrase;

        private string more;

        private static readonly string refBase = "http://openmessaging.cloud/internal/code";

        OMSResponseStatus(int statusCode, string reasonPhrase)
        {
            this.statusCode = statusCode;

            this.reasonPhrase = reasonPhrase;

            this.more = generateReasonLocation(statusCode, reasonPhrase);
        }

        public int getStatusCode()
        {
            return statusCode;
        }

        public string getMore()
        {
            return more;
        }

        public string getReasonPhrase()
        {
            return reasonPhrase;
        }

        public static OMSRuntimeException generateException(OMSResponseStatus status, params string[] messageArgs)
        {
            return new OMSRuntimeException(status.getStatusCode(), string.Format(status.getMore(), messageArgs));
        }

        public static OMSRuntimeException generateException(OMSResponseStatus status)
        {
            return new OMSRuntimeException(status.getStatusCode(), status.getMore());
        }

        public static OMSRuntimeException generateException(int statusCode, string reasonPhrase)
        {
            return new OMSRuntimeException(statusCode, reasonPhrase);
        }

        public static string generateReasonLocation(int statusCode, string reasonPhrase)
        {
            return reasonPhrase + "\nFor more information, please visit the URL, " + refBase + "#" + statusCode;
        }
    }
}