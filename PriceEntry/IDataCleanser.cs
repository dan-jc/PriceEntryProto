namespace PriceEntry;

public interface IDataCleanser<TDataIn,TDataOut>
{
    public TDataOut Run(TDataIn data);
}