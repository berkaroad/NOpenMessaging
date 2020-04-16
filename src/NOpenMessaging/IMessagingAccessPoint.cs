using NOpenMessaging.Consuming;
using NOpenMessaging.Managers;
using NOpenMessaging.Messaging;
using NOpenMessaging.Producing;

namespace NOpenMessaging
{

    /**
     * An instance of {@code MessagingAccessPoint} may be obtained from {@link OMS}, which is capable of creating {@code
     * Producer}, {@code Consumer}, {@code ResourceManager}, and other facility entities.
     * <p>
     * For example:
     * <pre>
     * MessagingAccessPoint messagingAccessPoint = OMS.getMessagingAccessPoint("oms:rocketmq://alice@rocketmq.apache.org/us-east:default_space");
     * messagingAccessPoint.startup();
     * Producer producer = messagingAccessPoint.createProducer();
     * producer.startup();
     * producer.send(producer.createBytesMessage("HELLO_QUEUE", "HELLO_BODY".getBytes(Charset.forName("UTF-8"))));
     * </pre>
     *
     * @version OMS 1.0.0
     * @since OMS 1.0.0
     */
    public interface IMessagingAccessPoint
    {

        /**
         * Returns the target OMS specification version of the specified vendor implementation.
         *
         * @return the OMS version of implementation
         * @see OMS#specVersion
         */
        string version();

        /**
         * Returns the attributes of this {@code MessagingAccessPoint} instance.
         * <p>
         * There are some standard attributes defined by OMS for {@code MessagingAccessPoint}:
         * <ul>
         * <li> {@link OMSBuiltinKeys#ACCESS_POINTS}, the specified access points.
         * <li> {@link OMSBuiltinKeys#DRIVER_IMPL}, the fully qualified class name of the specified MessagingAccessPoint's
         * implementation, the default value is {@literal NOpenMessaging.<driver_type>.MessagingAccessPointImpl}.
         * <li> {@link OMSBuiltinKeys#REGION}, the region the resources reside in.
         * <li> {@link OMSBuiltinKeys#ACCOUNT_ID}, the ID of the specific account system that owns the resource.
         * </ul>
         *
         * @return the attributes
         */
        IKeyValue attributes();

        /**
         * Creates a new {@code Producer} for the specified {@code MessagingAccessPoint}.
         *
         * @return the created {@code Producer}
         * @throws OMSRuntimeException if the {@code MessagingAccessPoint} fails to handle this request due to some internal
         * error
         * @throws OMSSecurityException if have no authority to create a producer.
         */
        IProducer createProducer();

        /**
         * Creates a new transactional {@code Producer} for the specified {@code MessagingAccessPoint}, the producer is able
         * to respond to requests from the server to check the status of the transaction.
         *
         * @param transactionStateCheckListener transactional check listener {@link TransactionStateCheckListener}
         * @return the created {@code Producer}
         * @throws OMSRuntimeException if the {@code MessagingAccessPoint} fails to handle this request due to some internal
         * error
         * @throws OMSSecurityException if have no authority to create a producer.
         */
        IProducer createProducer(ITransactionStateCheckListener transactionStateCheckListener);

        /**
         * Creates a new {@code PushConsumer} for the specified {@code MessagingAccessPoint}.
         * The returned {@code PushConsumer} isn't attached to any queue,
         * uses {@link PushConsumer#bindQueue(Collection, MessageListener)} to attach queues.
         *
         * @return the created {@code PushConsumer}
         * @throws OMSRuntimeException if the {@code MessagingAccessPoint} fails to handle this request
         * due to some internal error
         */
        IPushConsumer createPushConsumer();

        /**
         * Creates a new {@code PullConsumer} for the specified {@code MessagingAccessPoint}.
         *
         * @return the created {@code PullConsumer}
         * @throws OMSRuntimeException if the {@code MessagingAccessPoint} fails to handle this request
         * due to some internal error
         */
        IPullConsumer createPullConsumer();

        /**
         * Creates a new {@code PushConsumer} for the specified {@code MessagingAccessPoint} with some preset attributes.
         *
         * @param attributes the preset attributes
         * @return the created {@code PushConsumer}
         * @throws OMSRuntimeException if the {@code MessagingAccessPoint} fails to handle this request
         * due to some internal error
         */
        IPushConsumer createPushConsumer(IKeyValue attributes);

        /**
         * Creates a new {@code PullConsumer} for the specified {@code MessagingAccessPoint}.
         *
         * @return the created {@code PullConsumer}
         * @throws OMSRuntimeException if the {@code MessagingAccessPoint} fails to handle this request
         * due to some internal error
         */
        IPullConsumer createPullConsumer(IKeyValue attributes);

        /**
         * Gets a lightweight {@code ResourceManager} instance from the specified {@code MessagingAccessPoint}.
         *
         * @return the resource manger
         * @throws OMSRuntimeException if the {@code MessagingAccessPoint} fails to handle this request due to some internal
         * error
         * @throws OMSSecurityException if have no authority to obtain a resource manager.
         */
        IResourceManager resourceManager();

        /**
         * Gets a {@link MessageFactory} instance from the specified {@code MessagingAccessPoint}.
         *
         * @return the resource manger
         * @throws OMSRuntimeException if the {@code MessagingAccessPoint} fails to handle this request due to some internal
         * error
         */
        IMessageFactory messageFactory();
    }
}