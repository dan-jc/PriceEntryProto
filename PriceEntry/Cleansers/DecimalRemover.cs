namespace PriceEntry.Cleansers;

public static class DecimalRemover
{
    public static CleansedResult<string> Cleanse(string fieldName, string fieldValue)
    {
        var decimalsTrimmed = fieldValue.TrimEnd('.');

        var status = new CleanseStatus(true, fieldName, fieldValue);
        return new CleansedResult<string>(status, decimalsTrimmed);
    }
}