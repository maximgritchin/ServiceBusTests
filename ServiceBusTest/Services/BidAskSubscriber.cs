using MyJetWallet.Domain.ServiceBus;
using MyJetWallet.Sdk.ServiceBus;
using MyServiceBus.Abstractions;
using MyServiceBus.TcpClient;

namespace ServiceBusTest.Services;

public class BidAskSubscriber : Subscriber<BidAskSbMessage>
{
    public BidAskSubscriber(
        MyServiceBusTcpClient client, string queueName, TopicQueueType type, bool isChunk)
        : base(
            client, "bid-ask", queueName, type,
            bytes => bytes.ByteArrayToServiceBusContract<BidAskSbMessage>(), isChunk
        )
    {
    }
}