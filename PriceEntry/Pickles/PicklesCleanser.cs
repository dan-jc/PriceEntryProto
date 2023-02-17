using PriceEntry.Cleansers;

namespace PriceEntry.Pickles;

public class PicklesCleanser
{
    private readonly IPriceCleanser _priceCleanser;
    private readonly IStringMapCleanser _makeCleanser;
    private readonly IStringMapCleanser _familyCleanser;


    public PicklesCleanser(IPriceCleanser priceCleanser, IStringMapCleanser makeCleanser, IStringMapCleanser familyCleanser)
    {
        _priceCleanser = priceCleanser;
        _makeCleanser = makeCleanser;
        _familyCleanser = familyCleanser;
    }

    public PicklesCleansedRecord Cleanse(PicklesRawRecord rawRecord)
    {
        var makeCleanserDelegate = new StringOperation<string>(_makeCleanser.Cleanse);
        var familyCleanserDelegate = new StringOperation<string>(_familyCleanser.Cleanse);
        var priceCleanserDelegate = new StringOperation<int?>(_priceCleanser.Cleanse);

        var makeCleanseResult = makeCleanserDelegate(nameof(rawRecord.Make),rawRecord.Make);
        var familyCleanseResult = familyCleanserDelegate(nameof(rawRecord.Model),rawRecord.Model);
        var priceCleanseResult = priceCleanserDelegate(nameof(rawRecord.SalePriceEcg), rawRecord.SalePriceEcg);

        var cleansedRecord = new PicklesCleansedRecord
        {
            Make = makeCleanseResult.CleansedData,
            Model = familyCleanseResult.CleansedData,
            SalePriceEcg = priceCleanseResult.CleansedData.Value
        };

        return cleansedRecord;
    }
}