namespace PriceEntry.Carsales.RecordTypes;

public class CarsalesCleansedRecord
{
    public Guid Id { get; set; }
    public string Make { get; set; }
    public int Price { get; set; }

    public CarsalesCleansedRecord(Guid id, string make, int price)
    {
        Id = id;
        Make = make;
        Price = price;
    }
}