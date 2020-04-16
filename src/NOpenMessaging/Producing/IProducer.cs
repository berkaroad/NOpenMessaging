using System.Collections.Generic;
using NOpenMessaging.Interceptors;
using NOpenMessaging.Messaging;

namespace NOpenMessaging.Producing
{
    /**
     * A {@code Producer} is a simple object used to send messages on behalf of a {@code MessagingAccessPoint}. An instance
     * of {@code Producer} is created by calling the {@link MessagingAccessPoint#createProducer()} method.
     * <p>
     * It provides various {@code send} methods to send a message to a specified destination, which is a {@code Queue} in
     * OMS.
     * <p>
     * {@link Producer#send(Message)} means send a message to the destination synchronously, the calling thread will block
     * until the send request complete.
     * <p>
     * {@link Producer#sendAsync(Message)} means send a message to the destination asynchronously, the calling thread won't
     * block and will return immediately. Since the send call is asynchronous it returns a {@link Future} for the send
     * result.
     *
     * @version OMS 1.0.0
     * @since OMS 1.0.0
     */
    public interface IProducer : IMessageFactory, IServiceLifecycle, IClient
    {

        /**
         * Sends a message to the specified destination synchronously, the destination should be preset to {@link
         * Message#header()}, other header fields as well.
         *
         * @param message a message will be sent.
         * @return the successful {@code SendResult}.
         * @throws OMSSecurityException when have no authority to send messages to a given destination.
         * @throws OMSMessageFormatException when an invalid message is specified.
         * @throws OMSTimeOutException when the given timeout elapses before the send operation completes.
         * @throws OMSDestinationException when have no given destination in the server.
         * @throws OMSRuntimeException when the {@code Producer} fails to send the message due to some internal error.
         */
        ISendResult send(IMessage message);

        /**
         * Sends a message to the specified destination asynchronously, the destination should be preset to {@link
         * Message#header()}, other header fields as well.
         * <p>
         * The returned {@code Promise} will have the result once the operation completes, and the registered {@code
         * FutureListener} will be notified, either because the operation was successful or because of an error.
         *
         * @param message a message will be sent.
         * @return the {@code Promise} of an asynchronous message send operation.
         * @see Future
         * @see FutureListener
         */
        IFuture<ISendResult> sendAsync(IMessage message);

        /**
         * <p>
         * There is no {@code Promise} related or {@code RuntimeException} thrown. The calling thread doesn't care about the
         * send result and also have no context to get the result.
         *
         * @param message a message will be sent.
         */
        void sendOneway(IMessage message);

        /**
         * <p>
         * Send batch messages to server.
         *
         * @param messages messages to be sent.
         */
        void send(IList<IMessage> messages);

        /**
         * Send messages to the specified destination asynchronously, the destination should be preset to {@link
         * Message#header()}, other header fields as well.
         * <p>
         * The returned {@code Promise} will have the result once the operation completes, and the registered {@code
         * FutureListener} will be notified, either because the operation was successful or because of an error.
         *
         * @param messages a batch messages will be sent.
         * @return the {@code Promise} of an asynchronous messages send operation.
         * @see Future
         * @see FutureListener
         */
        IFuture<ISendResult> sendAsync(IList<IMessage> messages);

        /**
         * <p>
         * There is no {@code Promise} related or {@code RuntimeException} thrown. The calling thread doesn't care about the
         * send result and also have no context to get the result.
         *
         * @param messages a batch message will be sent.
         */
        void sendOneway(IList<IMessage> messages);

        /**
         * Adds a {@code ProducerInterceptor} to intercept send operations of producer.
         *
         * @param interceptor a producer interceptor.
         */
        void addInterceptor(IProducerInterceptor interceptor);

        /**
         * Remove a {@code ProducerInterceptor}.
         *
         * @param interceptor a producer interceptor will be removed.
         */
        void removeInterceptor(IProducerInterceptor interceptor);

        /**
         * Sends a transactional message to the specified destination synchronously, the destination should be preset to
         * {@link Message#header()}, other header fields as well.
         * <p>
         * A transactional send result will be exposed to consumer if this prepare message send success, and then, you can
         * execute your local transaction, when local transaction execute success, users can use {@link
         * TransactionalResult#commit()} to commit prepare message,otherwise can use {@link TransactionalResult#rollback()}
         * to roll back this prepare message.
         * </p>
         *
         * @param message a prepare transactional message will be sent.
         * @return the successful {@code SendResult}.
         * @throws OMSSecurityException when have no authority to send messages to a given destination.
         * @throws OMSMessageFormatException when an invalid message is specified.
         * @throws OMSTimeOutException when the given timeout elapses before the send operation completes.
         * @throws OMSDestinationException when have no given destination in the server.
         * @throws OMSRuntimeException when the {@code Producer} fails to send the message due to some internal error.
         * @throws OMSTransactionException when used normal producer which haven't register {@link
         * TransactionStateCheckListener}.
         */
        ITransactionalResult prepare(IMessage message);

    }
}