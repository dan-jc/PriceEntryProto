using PriceEntry.Carsales.PipeSections;

namespace PriceEntry.Carsales;

public class CarsalesPipeline : IPipeline
{
    private ICarsalesCollector Collector { get; }
    private ICarsalesCleanser Cleanser { get; }
    private ICarsalesMatcher Matcher { get; }
    private ICarsalesStandardiser Standardiser { get;  }

    public CarsalesPipeline(ICarsalesCollector collector, ICarsalesCleanser cleanser, ICarsalesMatcher matcher, ICarsalesStandardiser standardiser)
    {
        Collector = collector;
        Cleanser = cleanser;
        Matcher = matcher;
        Standardiser = standardiser;
    }

    public StandardRecord Run()
    {
        var rawData = Collector.Collect();
        var cleansedData = Cleanser.Cleanse(rawData);
        var matchedData = Matcher.Match(cleansedData);
        var standardisedRecords = Standardiser.Standardise(matchedData);

        return standardisedRecords;
    }
}