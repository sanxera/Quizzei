using QZI.Quizzei.Application.UseCases.Files.DownloadFile.Models.Request;
using QZI.Quizzei.Application.UseCases.Files.DownloadFile.Models.Response;

namespace QZI.Quizzei.Application.UseCases.Files.DownloadFile.Interfaces;

public interface IDownloadFileUseCase
{
    Task<DownloadFileResponse> ExecuteAsync(DownloadFileRequest request);
}