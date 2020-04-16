using System;

namespace NOpenMessaging.Attributes
{
    /// <summary>
    /// Represented these methods or interfaces are not mandatory in OpenMessaging.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class OptionalAttribute : Attribute
    {
    }
}