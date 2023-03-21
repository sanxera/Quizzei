using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoForUser.Models.Request;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoForUser.Models.Response;

namespace QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoForUser.Interfaces;

public interface IGetQuizzesInfoForUserUseCase
{
    Task<GetQuizzesInfoForUserResponse> ExecuteAsync(GetQuizzesInfoForUserRequest request);
}