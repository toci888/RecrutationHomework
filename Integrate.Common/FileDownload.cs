using Integrate.Common.Interfaces;

namespace Integrate.Common
{
    public class FileDownload : IFileDownload
    {
        public virtual async Task DownloadHttpFile(string fileUrl, string destinationPath)
        {
            await DownloadFileAsync(fileUrl, destinationPath);
        }

        protected virtual async Task DownloadFileAsync(string fileUrl, string destinationPath)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(fileUrl, HttpCompletionOption.ResponseHeadersRead))
                {
                    response.EnsureSuccessStatusCode();

                    using (Stream contentStream = await response.Content.ReadAsStreamAsync(),
                                  fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                    {
                        await contentStream.CopyToAsync(fileStream);
                        fileStream.Close();
                    }
                }
            }
        }
    }
}
