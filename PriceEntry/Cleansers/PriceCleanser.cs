namespace PriceEntry.Cleansers;

public interface IPriceCleanser
{
    CleansedResult<int?> Cleanse(string fieldName,  string fieldValue);
}

public class PriceCleanser : IPriceCleanser
{
    private List<StringOperation<string>> Operations;
    private List<CleanseStatus> cleanseStatuses;

    public CleansedResult<int?> Cleanse(string fieldName,  string fieldValue)
    {
        var commaRemoved = CommaRemover.Cleanse(fieldName, fieldValue);
        if (!commaRemoved.Status.Succeeded)
        {
            return new CleansedResult<int?>(commaRemoved.Status, null);
        }

        var decimalRemoved = DecimalRemover.Cleanse(fieldName, commaRemoved.CleansedData);

        if (!decimalRemoved.Status.Succeeded)
        {
            return new CleansedResult<int?>(decimalRemoved.Status, null);
        }

        if (int.TryParse(decimalRemoved.CleansedData, out var price))
        {
            var status = new CleanseStatus(true, fieldName, fieldValue);
            return new CleansedResult<int?>(status, price);
        }

        var failedStatus = new CleanseStatus(false, fieldName, fieldValue);
        return new CleansedResult<int?>(failedStatus, null);
    }
}