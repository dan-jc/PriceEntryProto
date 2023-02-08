namespace PriceEntry.Carsales;

public class CarsalesMappedRecord
{
    public Guid Id { get; set; }
    public string Rbc { get; set; }
    public string Make { get; set; }
    public int Price { get; set; }

    public CarsalesMappedRecord(Guid id, string rbc, string make, int price)
    {
        Id = id;
        Rbc = rbc;
        Make = make;
        Price = price;
    }
}