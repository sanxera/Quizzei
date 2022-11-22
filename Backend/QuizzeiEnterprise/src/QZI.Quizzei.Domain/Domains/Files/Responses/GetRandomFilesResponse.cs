using System.Collections.Generic;

namespace QZI.Quizzei.Domain.Domains.Files.Responses
{
    public class GetRandomFilesResponse
    {
        public IList<FileResponse> FilesResponse { get; set; } = new List<FileResponse>();
    }
}
