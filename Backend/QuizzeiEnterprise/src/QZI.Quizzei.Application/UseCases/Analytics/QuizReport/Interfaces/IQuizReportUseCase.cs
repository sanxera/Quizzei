using QZI.Quizzei.Application.UseCases.Analytics.QuizReport.Models.Request;
using QZI.Quizzei.Application.UseCases.Analytics.QuizReport.Models.Response;

namespace QZI.Quizzei.Application.UseCases.Analytics.QuizReport.Interfaces;

public interface IQuizReportUseCase
{
    Task<QuizReportResponse> ExecuteAsync(QuizReportRequest request);
}