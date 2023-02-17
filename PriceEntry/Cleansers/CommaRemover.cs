namespace PriceEntry.Cleansers;

internal class CommaRemover
{
    public static CleansedResult<string> Cleanse(string fieldName, string fieldValue)
    {
        var commaRemoved = fieldValue.Replace(",", string.Empty);

        var status = new CleanseStatus(true, fieldName, fieldValue);
        return new CleansedResult<string>(status, commaRemoved);
    }
}