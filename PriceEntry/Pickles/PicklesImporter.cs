using PriceEntry.Helper;

namespace PriceEntry.Pickles;

public class PicklesImporter : IRecordImporter<PicklesRawRecord>, IPipeline
{
    private string sourceDirectory = Path.Combine(AppContext.BaseDirectory, "MockData", "Pickles");

    private readonly ICsvFileHelper<PicklesRawRecord, PicklesRawRecordMap> _csvHelper;


    public PicklesImporter(ICsvFileHelper<PicklesRawRecord, PicklesRawRecordMap> csvHelper)
    {
        _csvHelper = csvHelper;
    }

    public List<PicklesRawRecord> ImportRecords()
    {
        var records = _csvHelper.ReadFiles(sourceDirectory);
        return records;
    }

    public StandardRecord Run()
    {
        throw new NotImplementedException();
    }
}