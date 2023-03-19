using System.Collections.Generic;

namespace QZI.Quizzei.Domain.Domains.Files.Responses;

public class GetFilesFromQuizInfoResponse
{
    public IList<FileResponse> FilesResponse { get; set; } = new List<FileResponse>();
}