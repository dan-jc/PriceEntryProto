using PriceEntry.Carsales.RecordTypes;

namespace PriceEntry.Carsales.PipeSections;

public interface ICarsalesCollector
{
    CarsalesRawRecord Collect();
}

public class CarsalesCollector : ICarsalesCollector
{
    public CarsalesRawRecord Collect()
    {
        return new CarsalesRawRecord(Guid.NewGuid(), "FoRd", "20,000");
    }
}