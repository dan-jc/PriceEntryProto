namespace PriceEntry.Cleansers;

public delegate CleansedResult<T> StringOperation<T>(string fieldName, string fieldValue);