using PriceEntry.Auction.RecordTypes;

namespace PriceEntry.Auction.PipeSections;

public interface IAuctionStandardiser
{
    StandardRecord Run(AuctionMappedRecord record);
}

public class AuctionStandardiser : IAuctionStandardiser
{
    public StandardRecord Run(AuctionMappedRecord record)
    {
        return new StandardRecord
            { Id = record.Id, Source = "CarSales", Rbc = record.Rbc, Make = record.Make, BasePrice = record.Price };

    }
}