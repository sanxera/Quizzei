using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.Analytics.QuizReportPerProcess.Interfaces;
using QZI.Quizzei.Application.UseCases.Analytics.QuizReportPerProcess.Models.Requests;

namespace QZI.Quizzei.API.Controllers.UseCases.Analytics.QuizReportPerUser;

[Route("api/analytics")]
public class AnalyticsController : MainController
{
    private readonly IQuizReportPerProcessUseCase _useCase;

    public AnalyticsController(IHttpContextAccessor contextAccessor, IQuizReportPerProcessUseCase useCase) : base(contextAccessor)
    {
        _useCase = useCase;
    }

    [HttpGet("generate-report-per-process/{quizProcessUuid:guid}")]
    public async Task<IActionResult> GenerateQuizReport(Guid quizProcessUuid)
    {
        var response = await _useCase.ExecuteAsync(new QuizReportPerProcessRequest { QuizProcessUuid = quizProcessUuid });
        return Ok(response);
    }
}