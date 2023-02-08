namespace PriceEntry;

public class CarsalesRawRecord
{
    public Guid Id { get; set; }
    public string Make { get; set; }
    public string Price { get; set; }

    public CarsalesRawRecord(Guid id, string make, string price)
    {
        Id = id;
        Make = make;
        Price = price;
    }
}