namespace PriceEntry.Cleansers;

public interface IStringMapCleanser
{
    CleansedResult<string> Cleanse(string fieldName ,string fieldValue);
}

public class StringMapCleanser : IStringMapCleanser
{
    private readonly Dictionary<string, string> _mappings;

    public StringMapCleanser(Dictionary<string, string> mappings)
    {
        _mappings = mappings;
    }

    public CleansedResult<string> Cleanse(string fieldName ,string fieldValue)
    {
        var status = new CleanseStatus(false, fieldName, fieldValue);

        if (!_mappings.ContainsKey(fieldValue)) return new CleansedResult<string>(status, null);

        status.Succeeded = true;
        var result = new CleansedResult<string>(status, _mappings[fieldValue]);

        return result;
    }
}