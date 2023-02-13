using PriceEntry.Auction.RecordTypes;
using PriceEntry.Carsales.RecordTypes;

namespace PriceEntry.Carsales.PipeSections;

public interface ICarsalesStandardiser
{
    StandardRecord Standardise(CarsalesMappedRecord record);
}

public class CarsalesStandardiser : ICarsalesStandardiser
{
    public StandardRecord Standardise(CarsalesMappedRecord record)
    {
        return new StandardRecord
            { Id = record.Id, Source = "CarSales", Rbc = record.Rbc, Make = record.Make, BasePrice = record.Price };

    }
}