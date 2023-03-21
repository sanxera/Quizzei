using QZI.Quizzei.Application.UseCases.QuizzesInformation.UpdateQuizInfo.Models.Request;

namespace QZI.Quizzei.Application.UseCases.QuizzesInformation.UpdateQuizInfo.Interfaces;

public interface IUpdateQuizInfoUseCase
{
    Task ExecuteAsync(Guid quizInfoUuid, UpdateQuizInfoRequest request);
}