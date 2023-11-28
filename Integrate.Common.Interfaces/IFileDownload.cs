using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrate.Common.Interfaces
{
    public interface IFileDownload
    {
        Task DownloadHttpFile(string fileUrl, string destinationPath);
    }
}
