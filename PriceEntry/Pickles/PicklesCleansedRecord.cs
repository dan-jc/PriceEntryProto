namespace PriceEntry.Pickles
{
    public class PicklesCleansedRecord
    {
        public string BranchName { get; set; }
        public string RedbookCode { get; set; }
        public string Vin { get; set; }
        public string Registration { get; set; }
        public string RegistationState { get; set; }
        public int OdometerReading { get; set; }
        public string VehicleCondition { get; set; }
        public string Colour { get; set; }
        public int SalePriceEcg { get; set; }
        public DateTime SaleDate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public SaleType DisposalType { get; set; }

    }
}
