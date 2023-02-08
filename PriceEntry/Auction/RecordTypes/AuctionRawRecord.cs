namespace PriceEntry.Auction.RecordTypes;

public class AuctionRawRecord
{
    public Guid Id { get; set; }
    public string Make { get; set; }
    public string Price { get; set; }

    public AuctionRawRecord(Guid id, string make, string price)
    {
        Id = id;
        Make = make;
        Price = price;
    }
}