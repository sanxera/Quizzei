using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoByUser.Models.Request;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoByUser.Models.Response;

namespace QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoByUser.Interfaces;

public interface IGetQuizzesInfoByUserUseCase
{
    Task<GetQuizzesInfoByUserResponse> ExecuteAsync(GetQuizzesInfoByUserRequest request);
}