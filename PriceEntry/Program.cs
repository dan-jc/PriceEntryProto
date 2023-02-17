using System.Text.Json;
using PriceEntry;
using PriceEntry.Helper;
using PriceEntry.Pickles;
using StructureMap;

Console.WriteLine(args.Length);

var container = new Container(_ =>
{
    _.Scan(x =>
    {
        x.AssemblyContainingType(typeof(Program)); ;
        x.RegisterConcreteTypesAgainstTheFirstInterface();
    });

    // Register a default instance for ICsvFileHelper<PicklesRawRecord, PicklesRawRecordMap>
    _.For<ICsvFileHelper<PicklesRawRecord, PicklesRawRecordMap>>()
        .Use(new CsvFileHelper<PicklesRawRecord, PicklesRawRecordMap>());
});
var pipelines = container.GetAllInstances<IPipeline>().ToList();

var standardisedRecords = new List<StandardRecord>();

foreach (var pipeline in pipelines)
{
    standardisedRecords.Add(pipeline.Run());
}




Console.Write(JsonSerializer.Serialize(standardisedRecords, new JsonSerializerOptions { WriteIndented = true }));
