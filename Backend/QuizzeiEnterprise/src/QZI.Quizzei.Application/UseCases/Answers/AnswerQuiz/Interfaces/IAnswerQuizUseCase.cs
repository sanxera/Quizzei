using QZI.Quizzei.Application.UseCases.Answers.AnswerQuiz.Models.Requests;
using QZI.Quizzei.Application.UseCases.Answers.AnswerQuiz.Models.Response;

namespace QZI.Quizzei.Application.UseCases.Answers.AnswerQuiz.Interfaces;

public interface IAnswerQuizUseCase
{
    Task<AnswerQuizResponse> ExecuteAsync(string emailOwner, Guid quizProcessUuid, AnswerQuizRequest request);
}