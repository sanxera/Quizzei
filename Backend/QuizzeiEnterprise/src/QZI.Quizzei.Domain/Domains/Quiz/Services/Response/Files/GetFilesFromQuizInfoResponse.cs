using System.Collections.Generic;

namespace QZI.Quizzei.Domain.Domains.Quiz.Services.Response.Files
{
    public class GetFilesFromQuizInfoResponse
    {
        public IList<FileResponse> FilesResponse { get; set; } = new List<FileResponse>();
    }
}
