using System.IO;

namespace QZI.Quizzei.Domain.Domains.Quiz.Services.Response.Files
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
