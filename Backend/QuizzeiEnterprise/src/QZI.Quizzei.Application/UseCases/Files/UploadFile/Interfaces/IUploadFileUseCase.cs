using QZI.Quizzei.Application.UseCases.Files.UploadFile.Models.Response;

namespace QZI.Quizzei.Application.UseCases.Files.UploadFile.Interfaces;

public interface IUploadFileUseCase
{
    Task<UploadFileResponse> ExecuteAsync(Guid quizInfoUuid, string fileName, Stream fileStream);
}