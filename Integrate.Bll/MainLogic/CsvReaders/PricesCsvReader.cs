using Integrate.Bll.Parsing;
using Integrate.Common.Interfaces;
using Integrate.Database.Persistence.Models;
using Integrate.Models;

namespace Integrate.Bll.MainLogic.CsvReaders
{
    public class PricesCsvReader : CsvReaderBase<Price, PricesModel>
    {
        protected IDbHandle<Product> DbHandle = new IntegrateDbHandle<Product>();

        public PricesCsvReader()
        {
            CsvParser = new ParsePrices();
            Path = FileMetadata.FilePricesName;
            Delimiter = ",";
            SkipFirstLine = false;
        }

        protected override bool Qualify(PricesModel csvModel)
        {
            Product product = DbHandle.Select(m => m.Sku == csvModel.SKU).FirstOrDefault();

            return product != null;
        }
    }
}
