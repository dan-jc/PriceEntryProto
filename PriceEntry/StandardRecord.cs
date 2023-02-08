namespace PriceEntry;

public class StandardRecord
{
    public Guid Id { get; set; }
    public string Source { get; set; }
    public string Rbc { get; set; }
    public string Make { get; set; }
    public int BasePrice { get; set; }
    public int PriceWithTax { get; set; }
}