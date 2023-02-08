using PriceEntry.Auction.RecordTypes;

namespace PriceEntry.Auction.PipeSections;

public interface IAuctionCollector
{
    AuctionRawRecord Run();
}

public class AuctionCollector : IAuctionCollector
{
    public AuctionRawRecord Run()
    {
        return new AuctionRawRecord(Guid.NewGuid(), "hoLden", "40,000");
    }
}