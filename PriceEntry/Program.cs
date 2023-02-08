// See https://aka.ms/new-console-template for more information


using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using PriceEntry;
using StructureMap;

//static void Main(string[] args)
//{
//    var services = new ServiceCollection( )
//}


Console.WriteLine(args.Length);


var container = new Container();
container.Configure(config =>
{
    // Register stuff in container, using the StructureMap APIs...
    config.Scan(_ =>
    {
        _.AssemblyContainingType(typeof(Program));
        //_.AddAllTypesOf<IPipeline>();
        _.RegisterConcreteTypesAgainstTheFirstInterface();

    });
    // Populate the container using the service collection
    config.Populate(new ServiceCollection());
});

//var container = new Container(_ =>
//{
//    //_.For<IPipeline>().Use<Pipeline>();
//    //_.For<IPipeline>().Use<CarsalesPipeline>();
//    _.Scan(x =>
//    {
//        x.AssemblyContainingType(typeof(Program)); ;
//        //x.AddAllTypesOf<IPipeline>();
//        x.WithDefaultConventions();
//    });
//});
//var pipelines = container.GetAllInstances<IPipeline>().ToList();

var standardisedRecords = new List<StandardRecord>();

var serviceProvider = container.GetInstance<IServiceProvider>();
var pipelines = serviceProvider.GetServices<IPipeline>().ToList();
//standardisedRecords.Add(pipelines.Run());

foreach (var pipeline in pipelines)
{
    standardisedRecords.Add(pipeline.Run());
}

Console.WriteLine(JsonSerializer.Serialize(standardisedRecords));

