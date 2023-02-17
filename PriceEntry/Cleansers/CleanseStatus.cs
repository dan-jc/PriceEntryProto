namespace PriceEntry.Cleansers;

public class CleanseStatus
{
    public bool Succeeded;
    public string FieldName;
    public string FieldValue;

    public CleanseStatus(bool succeeded, string fieldName, string fieldValue)
    {
        Succeeded = succeeded;
        FieldName = fieldName;
        FieldValue = fieldValue;
    }
}