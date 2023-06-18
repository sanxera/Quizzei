using QZI.Quizzei.Application.UseCases.Analytics.QuizReportPerCategory.Models.Request;
using QZI.Quizzei.Application.UseCases.Analytics.QuizReportPerCategory.Models.Response;

namespace QZI.Quizzei.Application.UseCases.Analytics.QuizReportPerCategory.Interfaces
{
    public interface IQuizReportPerCategoryUseCase
    {
        Task<QuizReportPerCategoryResponse> ExecuteAsync(QuizReportPerCategoryRequest request);
    }
}
