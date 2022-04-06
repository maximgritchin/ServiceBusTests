using DotNetCoreDecorators;
using Newtonsoft.Json;
using ServiceBusTest.Services;

namespace ServiceBusTest.Jobs;

public class BidAskJob
{
    private readonly ISubscriber<BidAskSbMessage> _subscriber;

    public BidAskJob(ISubscriber<BidAskSbMessage> subscriber)
    {
        subscriber.Subscribe(HandleBidAsk);
    }

    private ValueTask HandleBidAsk(BidAskSbMessage mess)
    {
        Console.WriteLine(JsonConvert.SerializeObject(mess));
        
        return ValueTask.CompletedTask;
    }
}