using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.Analytics.QuizReportPerCategory.Interfaces;
using QZI.Quizzei.Application.UseCases.Analytics.QuizReportPerCategory.Models.Request;

namespace QZI.Quizzei.API.Controllers.UseCases.Analytics.QuizReportPerCategory;

[Route("api/analytics")]
public class AnalyticsController : MainController
{
    private readonly IQuizReportPerCategoryUseCase _useCase;

    public AnalyticsController(IHttpContextAccessor contextAccessor, IQuizReportPerCategoryUseCase useCase) : base(contextAccessor)
    {
        _useCase = useCase;
    }

    [HttpGet("generate-quiz-report-per-category/{quizUuid:guid}")]
    public async Task<IActionResult> GenerateQuizReport(Guid quizUuid)
    {
        var response = await _useCase.ExecuteAsync(new QuizReportPerCategoryRequest { QuizUuid = quizUuid});
        return Ok(response);
    }
}