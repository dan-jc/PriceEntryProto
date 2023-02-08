namespace PriceEntry.Auction.RecordTypes;

public class AuctionMappedRecord
{
    public Guid Id { get; set; }
    public string Rbc { get; set; }
    public string Make { get; set; }
    public int Price { get; set; }

    public AuctionMappedRecord(Guid id, string rbc, string make, int price)
    {
        Id = id;
        Rbc = rbc;
        Make = make;
        Price = price;
    }
}