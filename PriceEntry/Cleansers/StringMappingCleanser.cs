using System.Runtime.InteropServices.ComTypes;

namespace PriceEntry.Cleansers;

public class StringMappingCleanser
{
    private readonly Dictionary<string, string> _mappings;
    private readonly string _name;

    public StringMappingCleanser(Dictionary<string, string> mappings, string name)
    {
        _mappings = mappings;
        _name = name;
    }

    public CleansedResult<string> Cleanse(string unCleansed)
    {
        var status = new CleanseStatus(false, _name, unCleansed);

        if (!_mappings.ContainsKey(unCleansed)) return new CleansedResult<string>(status, null);

        status.Succeeded = true;
        var result = new CleansedResult<string>(status, _mappings[unCleansed]);

        return result;

    }

}