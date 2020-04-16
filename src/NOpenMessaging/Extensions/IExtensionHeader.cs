using NOpenMessaging.Attributes;

namespace NOpenMessaging.Extensions
{
    /// <summary>
    /// Extended properties for common implementations in current messaging
    /// and streaming field, such as the queue-based partitioning implementation, but the related properties in this
    /// interface are not mandatory.
    /// </summary>
    [Optional]
    public interface IExtensionHeader
    {
        /// <summary>
        /// The specified PARTITION will be sent to.
        /// </summary>
        /// <remarks>
        /// When a <see cref="Message" /> is set with this value, this message will be delivered to specified partition, but the
        /// premise is that the implementation of the server side is dependent on the partition or a queue-like storage
        /// mechanism.
        /// </remarks>
        int Partiton { get; set; }

        /// <summary>
        /// The OFFSET in the current partition, used to quickly get this message in the queue.
        /// </summary>
        /// <remarks>This method is only called by the server</remarks>
        long Offset { get; set; }

        /// <summary>
        /// CORRELATION_ID to link one message with another.
        /// </summary>
        string CorrelationId { get; set; }

        /// <summary>
        /// TRANSACTION_ID is used in transactional message, and it can be used to trace a transaction.
        /// </summary>
        /// <remarks>
        /// So the same TRANSACTION_ID will be appeared not only in prepare message, but also in commit message, and
        /// consumer received message also contains this field.
        /// </remarks>
        string TransactionId { get; set; }

        /// <summary>
        /// The STORE_TIMESTAMP of a message in server side.
        /// </summary>
        /// <remarks>
        /// When a message is sent, STORE_TIMESTAMP is ignored.
        /// When the send method returns it contains a server-assigned value.
        /// This filed is a {@code long} value, measured in milliseconds.
        /// </remarks>
        long StoreTimestamp { get; set; }

        /// <summary>
        /// The STORE_HOST header field contains the store host info of a message in server side.
        /// </summary>
        /// <remarks>
        /// When a message is sent, STORE_HOST is ignored.
        /// When the send method returns it contains a server-assigned value.
        /// </remarks>
        string StoreHost { get; set; }

        /// <summary>
        /// The DELAY_TIME header field contains a number that represents the delayed times in milliseconds.
        /// </summary>
        /// <remarks>
        /// The message will be delivered after delayTime milliseconds starting from BORN_TIMESTAMP. When this filed
        /// isn't set explicitly, this means this message should be delivered immediately.
        /// </remarks>
        long DelayTime { get; set; }

        /**
         * See {@link ExtensionHeader#setExpireTime(long)}
         *
         * @return expireTime
         */
        /// <summary>
        /// The EXPIRE_TIME header field contains the expiration time, it represents a time-to-live value.
        /// </summary>
        /// <remarks>
        /// The EXPIRE_TIME represents a relative valid interval that a message can be delivered in it. If the
        /// EXPIRE_TIME field is specified as zero, that indicates the message does not expire.
        /// When an undelivered message's expiration time is reached, the message should be destroyed. OMS does not define a
        /// notification of message expiration.
        /// </remarks>
        long ExpireTime { get; set; }

        /// <summary>
        /// The messagekey header field contains the custom key of a message.
        /// </summary>
        /// <remarks>
        /// This key is a customer identifier for a class of messages, and this key may be used for server to hash or
        /// dispatch messages, or even can use this key to implement order message.
        /// </remarks>
        string MessageKey { get; set; }

        /// <summary>
        /// The TRACE_ID header field contains the trace ID of a message, which represents a global and unique
        /// identification, to associate key events in the whole lifecycle of a message, like sent by who, stored at where,
        /// and received by who.
        /// </summary>
        /// <remarks>
        /// And, the messaging system only plays exchange role in a distributed system in most cases, so the TraceID can be
        /// used to trace the whole call link with other parts in the whole system.
        /// </remarks>
        string TraceId { get; set; }
    }
}