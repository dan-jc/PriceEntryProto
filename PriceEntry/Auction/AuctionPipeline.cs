using PriceEntry.Auction.PipeSections;

namespace PriceEntry.Auction;

public class AuctionPipeline : IPipeline
{
    private IAuctionCollector Collector { get; }
    private IAuctionCleanser Cleanser { get; }
    private IAuctionMapper Mapper { get; }
    private IAuctionStandardiser Standardiser { get;  }

    public AuctionPipeline(IAuctionCollector collector, IAuctionCleanser cleanser, IAuctionMapper mapper, IAuctionStandardiser standardiser)
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