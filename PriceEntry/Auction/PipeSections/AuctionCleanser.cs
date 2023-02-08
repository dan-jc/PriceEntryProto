using PriceEntry.Auction.RecordTypes;

namespace PriceEntry.Auction.PipeSections;

public interface IAuctionCleanser
{
    public AuctionCleansedRecord Run(AuctionRawRecord record);
}

public class AuctionCleanser : IAuctionCleanser
{
    public AuctionCleanser(IWordCleanser wordCleanser)
    {
        _wordCleanser = wordCleanser;
    }

    private IWordCleanser _wordCleanser { get; set; }
       
        
    public AuctionCleansedRecord Run(AuctionRawRecord record)
    {
        var cleansedData = new AuctionCleansedRecord
        {
            Id = record.Id,
            Make = _wordCleanser.CleanseWord(record.Make),
            Price = CleanPrice(record.Price)
        };
        return cleansedData;
    }

    private int CleanPrice(string price)
    {
        return int.TryParse(price.Replace(",", ""), out var cleanedPrice) ? cleanedPrice : 0;
    }
}