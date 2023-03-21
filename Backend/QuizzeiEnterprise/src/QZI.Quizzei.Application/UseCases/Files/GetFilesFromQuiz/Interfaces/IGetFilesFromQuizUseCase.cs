using QZI.Quizzei.Application.UseCases.Files.GetFilesFromQuiz.Models.Request;
using QZI.Quizzei.Application.UseCases.Files.GetFilesFromQuiz.Models.Response;

namespace QZI.Quizzei.Application.UseCases.Files.GetFilesFromQuiz.Interfaces;

public interface IGetFilesFromQuizUseCase
{
    Task<GetFilesFromQuizInfoResponse> ExecuteAsync(GetFilesFromQuizInfoRequest request);
}