using System.Runtime.Serialization;

namespace ServiceBusTest.Services;

[DataContract]
public class BidAskSbMessage
{
    [DataMember(Order = 1)]
    public string Id { get; set; }
    [DataMember(Order = 2)]
    public long DateTime { get; set; }
    [DataMember(Order = 3)]
    public double Bid { get; set; }
    [DataMember(Order = 4)]
    public double Ask { get; set; }
}
