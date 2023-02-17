namespace PriceEntry.Cleansers;

public interface ICleanser<T>
{
    List<StringOperation> Operations { get; set; }
    CleansedResult<T> Cleanse(string unCleansed);
}