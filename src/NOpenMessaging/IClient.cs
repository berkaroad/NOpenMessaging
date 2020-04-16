using NOpenMessaging.Attributes;
using NOpenMessaging.Extensions;

namespace NOpenMessaging
{
    /// <summary>
    /// A <see cref="IClient" /> interface contains all the common behaviors of producer and consumer. which can be used to achieve
    /// some basic interaction with the server.
    /// </summary>
    public interface IClient
    {
        /// <summary>
        /// Get the extension method, and this interface is optional, Therefore, users need to check whether this interface
        /// has been implemented by vendors.
        /// </summary>
        /// <returns>the implementation of <see cref="IExtension" /></returns>
        [Optional]
        IExtension getExtension();
    }
}