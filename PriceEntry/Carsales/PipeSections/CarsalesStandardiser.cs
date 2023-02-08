namespace PriceEntry.Carsales.PipeSections;

public interface ICarsalesStandardiser
{
    StandardRecord Run(CarsalesMappedRecord record);
}

public class CarsalesStandardiser : ICarsalesStandardiser
{
    public StandardRecord Run(CarsalesMappedRecord record)
    {
        return new StandardRecord
            { Id = record.Id, Source = "CarSales", Rbc = record.Rbc, Make = record.Make, BasePrice = record.Price };

    }
}