using DotNetCoreDecorators;
using MyJetWallet.Sdk.ServiceBus;
using ServiceBusTest.Services;

namespace ServiceBusTest.Jobs;

public class BidAskPublishJob
{
    private readonly MyServiceBusPublisher<BidAskSbMessage> _publisher;

    public BidAskPublishJob(MyServiceBusPublisher<BidAskSbMessage> publisher)
    {
        _publisher = publisher;
        Timer.Register("publish-bid-ask", async () => await PublishBidAsk());
        Timer.Start();
    }
    
    private TaskTimer Timer = new (TimeSpan.FromSeconds(3));
    
    private async ValueTask PublishBidAsk()
    {
        Console.Write($"Update BidAsk...");
        await _publisher.PublishAsync(new BidAskSbMessage
        {
            Id = "1",
            Ask = 123,
            Bid = 456,
            DateTime = DateTime.Now.UnixTime()
        });
    }
}