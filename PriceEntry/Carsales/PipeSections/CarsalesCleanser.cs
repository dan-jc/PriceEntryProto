using PriceEntry.Carsales.RecordTypes;

namespace PriceEntry.Carsales.PipeSections;

public interface ICarsalesCleanser
{
    public CarsalesCleansedRecord Cleanse(CarsalesRawRecord record);
}

public class CarsalesCleanser : ICarsalesCleanser
{
    public CarsalesCleanser(IWordCleanser wordCleanser)
    {
        _wordCleanser = wordCleanser;
    }

    private IWordCleanser _wordCleanser { get; set; }
       
        
    public CarsalesCleansedRecord Cleanse(CarsalesRawRecord record)
    {
        var cleansedMake = _wordCleanser.CleanseWord(record.Make);
        var cleansedPrice = CleanPrice(record.Price);
        var cleansedData = new CarsalesCleansedRecord(record.Id, cleansedMake, cleansedPrice);
        return cleansedData;
    }

    private int CleanPrice(string price)
    {
        return int.TryParse(price.Replace(",", ""), out var cleanedPrice) ? cleanedPrice : 0;
    }

    
}