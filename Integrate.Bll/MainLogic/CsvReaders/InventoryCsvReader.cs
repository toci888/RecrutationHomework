using Integrate.Bll.Parsing;
using Integrate.Database.Persistence.Models;
using Integrate.Models;

namespace Integrate.Bll.MainLogic.CsvReaders
{
    public class InventoryCsvReader : CsvReaderBase<Inventory, InventoryModel>
    {
        public InventoryCsvReader()
        {
            CsvParser = new ParseInventory();
            Path = FileMetadata.FileInventoryName;
            Delimiter = ",";
            SkipFirstLine = true;
        }

        protected override bool Qualify(InventoryModel csvModel)
        {
            if (csvModel.shipping == "24h")
            {
                return true;
            }

            return false;
        }
    }
}
