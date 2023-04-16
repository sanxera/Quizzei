using QZI.Quizzei.Application.UseCases.Analytics.QuizReport.Models.Request;

namespace QZI.Quizzei.Application.UseCases.Analytics.QuizReportPerUser.Interfaces
{
    public interface IQuizReportPerUserUseCase
    {
        Task ExecuteAsync(QuizReportPerUseRequest request);
    }
}
