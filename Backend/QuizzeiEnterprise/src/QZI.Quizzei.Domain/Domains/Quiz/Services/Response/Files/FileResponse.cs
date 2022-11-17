using System;

namespace QZI.Quizzei.Domain.Domains.Quiz.Services.Response.Files
{
    public class FileResponse
    {
        public Guid FileCreatedUuid { get; set; }
        public string FileName { get; set; }

        public FileResponse(Guid fileCreatedUuid, string fileName)
        {
            FileCreatedUuid = fileCreatedUuid;
            FileName = fileName;
        }
    }
}