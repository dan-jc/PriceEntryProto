using PriceEntry.Carsales.RecordTypes;

namespace PriceEntry.Carsales.PipeSections;

public interface ICarsalesCollector
{
    CarsalesRawRecord Run();
}

public class CarsalesCollector : ICarsalesCollector
{
    public CarsalesRawRecord Run()
    {
        return new CarsalesRawRecord(Guid.NewGuid(), "FoRd", "20,000");
    }
}