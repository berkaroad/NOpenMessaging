using NOpenMessaging.Attributes;

namespace NOpenMessaging.Extensions
{
    /// <summary>
    /// Used for getting configurations related some certain implementation.
    /// but this interface are not mandatory.
    /// </summary>
    /// <remarks>
    /// In order to improve performance, in some scenarios where message persistence is required, some message middleware
    /// will store messages on multiple partitions in multi servers.
    /// In some scenarios, it is very useful to get the relevant partitions meta data for a queue.
    /// </remarks>
    [Optional]
    public interface IQueueMetaData
    {
        /// <summary>
        /// Queue Name
        /// </summary>
        string QueueName { get; set; }

        /// <summary>
        /// Partition identifier of target queue.
        /// </summary>
        int PartitionId { get; set; }
    }
}