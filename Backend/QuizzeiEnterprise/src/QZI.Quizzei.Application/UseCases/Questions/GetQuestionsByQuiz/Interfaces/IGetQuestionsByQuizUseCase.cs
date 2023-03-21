using QZI.Quizzei.Application.UseCases.Questions.GetQuestionsByQuiz.Models.Request;
using QZI.Quizzei.Application.UseCases.Questions.GetQuestionsByQuiz.Models.Response;

namespace QZI.Quizzei.Application.UseCases.Questions.GetQuestionsByQuiz.Interfaces;

public interface IGetQuestionsByQuizUseCase
{
    Task<GetQuestionsWithOptionsByQuizResponse> ExecuteAsync(GetQuestionsByQuizRequest request);
}