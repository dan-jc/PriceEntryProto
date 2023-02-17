namespace PriceEntry.Cleansers
{
    public class IntegerCleanser : ICleanser<int>
    {
        public List<StringOperation> Operations { get; set; }
        private readonly string _name;

        public IntegerCleanser(string name, List<StringOperation> operations)
        {
            _name = name;
            Operations = operations;
        }

        public CleansedResult<int> Cleanse(string unCleansed)
        {
            var cleansed = Operations.Aggregate(unCleansed, (current, operation) => operation(current));

            var decimalsTrimmed = unCleansed.TrimEnd('.');
            var commaRemoved = decimalsTrimmed.Replace(",", string.Empty);
            var currencySymbolRemoved = commaRemoved.Replace("$", string.Empty);

            if (int.TryParse(cleansed, out var integer))
            {
                var status = new CleanseStatus(true, _name, unCleansed);
                return new(status, integer);
            }

            var failedStatus = new CleanseStatus(false, _name, unCleansed);
            return new (failedStatus, 0);

        }
    }
}
