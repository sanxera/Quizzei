using System.IO;

namespace QZI.Quizzei.Domain.Domains.Files.Responses
{
    public class DownloadFileResponse
    {
        public Stream FileStream { get; set; }
        public string FileName { get; set; }

        public DownloadFileResponse(Stream fileStream, string fileName)
        {
            FileStream = fileStream;
            FileName = fileName;
        }
    }
}
