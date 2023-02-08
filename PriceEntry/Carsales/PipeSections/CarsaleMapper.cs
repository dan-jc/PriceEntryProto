using PriceEntry.Carsales.RecordTypes;

namespace PriceEntry.Carsales.PipeSections;

public interface ICarsalesMapper
{
    CarsalesMappedRecord Run(CarsalesCleansedRecord cleansedRecord);
}

public class CarsaleMapper :  ICarsalesMapper
{
    public CarsalesMappedRecord Run(CarsalesCleansedRecord cleansedRecord)
    {
        return new CarsalesMappedRecord(cleansedRecord.Id, "RedbookCode", cleansedRecord.Make, cleansedRecord.Price);
    }
}