using PriceEntry.Carsales.PipeSections;

namespace PriceEntry.Carsales;

public class CarsalesPipeline : IPipeline
{
    private ICarsalesCollector Collector { get; }
    private ICarsalesCleanser Cleanser { get; }
    private ICarsalesMapper Mapper { get; }
    private ICarsalesStandardiser Standardiser { get;  }

    public CarsalesPipeline(ICarsalesCollector collector, ICarsalesCleanser cleanser, ICarsalesMapper mapper, ICarsalesStandardiser standardiser)
    {
        Collector = collector;
        Cleanser = cleanser;
        Mapper = mapper;
        Standardiser = standardiser;
    }

    public StandardRecord Run()
    {
        var rawData = Collector.Run();
        var cleansedData = Cleanser.Run(rawData);
        var matchedData = Mapper.Run(cleansedData);
        var standardisedRecords = Standardiser.Run(matchedData);

        return standardisedRecords;
    }
}