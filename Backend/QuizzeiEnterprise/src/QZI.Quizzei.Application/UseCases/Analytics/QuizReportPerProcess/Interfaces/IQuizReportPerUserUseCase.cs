using QZI.Quizzei.Application.UseCases.Analytics.QuizReportPerProcess.Models.Requests;
using QZI.Quizzei.Application.UseCases.Analytics.QuizReportPerProcess.Models.Responses;

namespace QZI.Quizzei.Application.UseCases.Analytics.QuizReportPerProcess.Interfaces;

public interface IQuizReportPerProcessUseCase
{
    Task<QuizReportPerProcessResponse> ExecuteAsync(QuizReportPerProcessRequest request);
}