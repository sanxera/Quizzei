using QZI.Quizzei.Application.UseCases.QuizzesProcess.RatingQuiz.Models.Request;

namespace QZI.Quizzei.Application.UseCases.QuizzesProcess.RatingQuiz.Interfaces;

public interface IRatingQuizUseCase
{
    Task ExecuteAsync(RatingQuizRequest request);
}