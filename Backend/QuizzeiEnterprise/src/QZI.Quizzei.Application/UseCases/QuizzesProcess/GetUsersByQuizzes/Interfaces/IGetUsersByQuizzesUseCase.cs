using QZI.Quizzei.Application.UseCases.QuizzesProcess.GetUsersByQuizzes.Models.Request;
using QZI.Quizzei.Application.UseCases.QuizzesProcess.GetUsersByQuizzes.Models.Response;

namespace QZI.Quizzei.Application.UseCases.QuizzesProcess.GetUsersByQuizzes.Interfaces;

public interface IGetUsersByQuizzesUseCase
{
    Task<GetUsersByQuizzesResponse> ExecuteAsync(GetUsersByQuizzesRequest request);
}