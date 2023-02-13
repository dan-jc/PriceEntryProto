using PriceEntry.Carsales.RecordTypes;

namespace PriceEntry.Carsales.PipeSections;

public interface ICarsalesMatcher
{
    CarsalesMappedRecord Match(CarsalesCleansedRecord cleansedRecord);
}

public class CarsalesMatcher :  ICarsalesMatcher
{
    public CarsalesMappedRecord Match(CarsalesCleansedRecord cleansedRecord)
    {
        return new CarsalesMappedRecord(cleansedRecord.Id, "RedbookCode", cleansedRecord.Make, cleansedRecord.Price);
    }
}