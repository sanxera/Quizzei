using System;
using System.IO;
using System.Threading.Tasks;
using QZI.Quizzei.Domain.Domains.Files.Responses;

namespace QZI.Quizzei.Domain.Domains.Quiz.Services.Abstractions
{
    public interface IFilesService
    {
        Task<UploadFileResponse> UploadFileToBucket(Guid quizInfoUuid, string fileName, Stream fileStream);
        Task<GetFilesFromQuizInfoResponse> GetFilesFromQuizInfo(Guid quizInfoUuid);
        Task<DownloadFileResponse> DownloadFileFromS3(Guid fileUuid);
        Task<GetRandomFilesResponse> GetRandomFiles();
    }
}
