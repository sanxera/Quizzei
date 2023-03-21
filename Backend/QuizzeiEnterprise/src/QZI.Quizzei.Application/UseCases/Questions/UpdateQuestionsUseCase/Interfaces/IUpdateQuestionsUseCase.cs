using QZI.Quizzei.Application.UseCases.Questions.UpdateQuestionsUseCase.Models.Request;

namespace QZI.Quizzei.Application.UseCases.Questions.UpdateQuestionsUseCase.Interfaces;

public interface IUpdateQuestionsUseCase
{
    Task ExecuteAsync(UpdateQuestionsRequest request);
}