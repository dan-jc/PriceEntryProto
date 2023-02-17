using PriceEntry.Cleansers;

namespace PriceEntry.Pickles
{
    public class PicklesPipeLine : IPipeline
    {
        private IRecordImporter<PicklesRawRecord> _importer;

        public PicklesPipeLine(IRecordImporter<PicklesRawRecord> importer)
        {
            _importer = importer;
        }

        public StandardRecord Run()
        {
            var rawRecords = _importer.ImportRecords();

            var makeCleanser = new StringMapCleanser(PicklesMapping.MakeMapping);
            var familyCleanser = new StringMapCleanser(PicklesMapping.FamilyMapping);

            var cleanser = new PicklesCleanser(new PriceCleanser(), makeCleanser, familyCleanser);
            return new StandardRecord();
        }
    }
}
