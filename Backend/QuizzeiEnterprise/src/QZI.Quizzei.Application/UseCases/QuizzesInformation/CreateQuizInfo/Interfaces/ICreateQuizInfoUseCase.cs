using QZI.Quizzei.Application.UseCases.QuizzesInformation.CreateQuizInfo.Models.Request;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.CreateQuizInfo.Models.Response;

namespace QZI.Quizzei.Application.UseCases.QuizzesInformation.CreateQuizInfo.Interfaces;

public interface ICreateQuizInfoUseCase
{
    Task<CreateQuizInfoResponse> CreateQuizInformation(string emailOwner, CreateQuizInfoRequest request);
}