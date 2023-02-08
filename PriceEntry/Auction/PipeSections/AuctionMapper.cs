using PriceEntry.Auction.RecordTypes;

namespace PriceEntry.Auction.PipeSections;

public interface IAuctionMapper
{
    AuctionMappedRecord Run(AuctionCleansedRecord cleansedRecord);
}

public class AuctionMapper : IAuctionMapper
{
    public AuctionMappedRecord Run(AuctionCleansedRecord cleansedRecord)
    {
        return new AuctionMappedRecord(cleansedRecord.Id, "RedbookCode", cleansedRecord.Make, cleansedRecord.Price);
    }
}