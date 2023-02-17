namespace PriceEntry.Cleansers;

public class CleansedResult<T>
{
    public CleanseStatus Status { get; set; }
    public T CleansedData { get; set; }

    public CleansedResult(CleanseStatus status, T cleansedData)
    {
        Status = status;
        CleansedData = cleansedData;
    }
}