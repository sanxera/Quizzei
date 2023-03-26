using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoFiles.Models.Request;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoFiles.Models.Response;

namespace QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoFiles.Interfaces;

public interface IGetQuizzesInfoFilesUseCase
{
    Task<GetFilesFromQuizInfoResponse> ExecuteAsync(GetFilesFromQuizInfoRequest request);
}