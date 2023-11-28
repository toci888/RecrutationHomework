using Integrate.Common.Interfaces;
using Integrate.Models;

namespace Integrate.Bll
{
    public class FileManager
    {
        protected List<DownloadFileModel> FilesToDownload = new List<DownloadFileModel>()
        {
            new DownloadFileModel() { FileName = FileMetadata.FileProductsName, FileUrl = FileMetadata.FileProductsUrl },
            new DownloadFileModel() { FileName = FileMetadata.FileInventoryName, FileUrl  = FileMetadata.FileInventoryUrl },
            new DownloadFileModel() { FileName = FileMetadata.FilePricesName, FileUrl  = FileMetadata.FilePricesUrl },
        };

        protected IFileDownload FileDownload;

        public FileManager(IFileDownload fileDownload) 
        {
            FileDownload = fileDownload;
        }

        public async void Download()
        {
            foreach (DownloadFileModel file in FilesToDownload)
            {
                await FileDownload.DownloadHttpFile(file.FileUrl, file.FileName);
            }
        }
    }
}
