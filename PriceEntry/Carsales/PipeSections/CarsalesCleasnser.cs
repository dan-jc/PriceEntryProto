using PriceEntry.Carsales.RecordTypes;

namespace PriceEntry.Carsales.PipeSections;

public interface ICarsalesCleanser
{
    //WordCleanser WordCleanser { get; set; }
    public CarsalesCleansedRecord Run(CarsalesRawRecord record);
}

public class CarsalesCleanser : ICarsalesCleanser
{
    public CarsalesCleanser(IWordCleanser wordCleanser)
    {
        _wordCleanser = wordCleanser;
    }

    private IWordCleanser _wordCleanser { get; set; }
       
        
    public CarsalesCleansedRecord Run(CarsalesRawRecord record)
    {
        var cleansedData = new CarsalesCleansedRecord
        {


            Id = record.Id,
            Make = _wordCleanser.CleanseWord(record.Make),
            Price = CleanPrice(record.Price)
        };
        return cleansedData;
    }

    private int CleanPrice(string price)
    {
        return int.TryParse(price.Replace(",", ""), out var cleanedPrice) ? cleanedPrice : 0;
    }

    
}