using System;

namespace QZI.Quizzei.Domain.Domains.Files.Responses;

public class UploadFileResponse
{
    public Guid FileCreatedUuid { get; set; }
    public string FileName { get; set; }

    public UploadFileResponse(Guid fileCreatedUuid, string fileName)
    {
        FileCreatedUuid = fileCreatedUuid;
        FileName = fileName;
    }
}