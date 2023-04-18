using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.Analytics.QuizReport.Interfaces;
using QZI.Quizzei.Application.UseCases.Analytics.QuizReport.Models.Request;

namespace QZI.Quizzei.API.Controllers.UseCases.Analytics.QuizReport;

[Route("api/analytics")]
public class AnalyticsController : MainController
{
    private readonly IQuizReportUseCase _useCase;

    public AnalyticsController(IHttpContextAccessor contextAccessor, IQuizReportUseCase useCase) : base(contextAccessor)
    {
        _useCase = useCase;
    }

    [HttpGet("generate-quiz-report/{quizUuid:guid}")]
    public async Task<IActionResult> GenerateQuizReport(Guid quizUuid)
    {
        var response = await _useCase.ExecuteAsync(new QuizReportRequest { QuizUuid = quizUuid});
        return Ok(response);
    }
}