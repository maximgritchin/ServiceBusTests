using DotNetCoreDecorators;
using MyJetWallet.Sdk.ServiceBus;
using MyServiceBus.Abstractions;
using MyServiceBus.TcpClient;
using ServiceBusTest.Jobs;
using ServiceBusTest.Services;

var builder = WebApplication.CreateBuilder(args);

const string APP_NAME = "test-service-bus";
var client = new MyServiceBusTcpClient(() => "127.0.0.1:6421", APP_NAME);

builder.Services.AddSingleton<ISubscriber<BidAskSbMessage>>(
    new BidAskSubscriber(client, APP_NAME, TopicQueueType.Permanent, false));
builder.Services.AddSingleton(
    new MyServiceBusPublisher<BidAskSbMessage>(client,"bid-ask", true));

builder.Services.AddSingleton<BidAskJob>();
builder.Services.AddSingleton<BidAskPublishJob>();

var app = builder.Build();

app.Services.GetService<BidAskJob>();
app.Services.GetService<BidAskPublishJob>();

client.Start();
app.Run();