using QZI.Quizzei.Application.UseCases.Files.GetRandomFiles.Models.Response;

namespace QZI.Quizzei.Application.UseCases.Files.GetRandomFiles.Interfaces;

public interface IGetRandomFilesUseCase
{
    Task<GetRandomFilesResponse> ExecuteAsync();
}