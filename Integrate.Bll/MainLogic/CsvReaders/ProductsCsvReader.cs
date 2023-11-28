using Integrate.Bll.Parsing;
using Integrate.Database.Persistence.Models;
using Integrate.Models;

namespace Integrate.Bll.MainLogic.CsvReaders
{
    public class ProductsCsvReader : CsvReaderBase<Product, ProductsModel>
    {
        public ProductsCsvReader() 
        {
            CsvParser = new ParseProducts();
            Path = FileMetadata.FileProductsName;
            Delimiter = ";";
            SkipFirstLine = true;
        }

        protected override bool Qualify(ProductsModel csvModel)
        {
            if (csvModel.is_wire == "0" && csvModel.shipping == "24h")
            {
                return true;
            }

            return false;
        }
    }
}
