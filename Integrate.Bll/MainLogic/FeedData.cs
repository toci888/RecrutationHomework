using Integrate.Bll.MainLogic.CsvReaders;
using Integrate.Common;

namespace Integrate.Bll.MainLogic
{
    public class FeedData
    {
        protected FileManager CsvFileManager = new FileManager(new FileDownload());

        protected ProductsCsvReader ProductsCsvReader = new ProductsCsvReader();
        protected InventoryCsvReader InventoryCsvReader = new InventoryCsvReader();
        protected PricesCsvReader PricesCsvReader = new PricesCsvReader();

        public FeedData() { }

        protected virtual void DownloadFiles()
        {
            CsvFileManager.Download();
        }

        public virtual bool RunParses()
        {
            DownloadFiles();

            ProductsCsvReader.ParseFile();
            InventoryCsvReader.ParseFile();
            PricesCsvReader.ParseFile();

            return true;
        }
    }
}
