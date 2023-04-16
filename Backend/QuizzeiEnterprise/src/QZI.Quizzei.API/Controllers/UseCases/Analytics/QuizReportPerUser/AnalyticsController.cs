using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.Analytics.QuizReport.Interfaces;
using QZI.Quizzei.Application.UseCases.Analytics.QuizReport.Models.Request;
using QZI.Quizzei.Application.UseCases.Analytics.QuizReportPerUser.Interfaces;
using QZI.Quizzei.Application.UseCases.Analytics.QuizReportPerUser.Models.Requests;

namespace QZI.Quizzei.API.Controllers.UseCases.Analytics.QuizReportPerUser
{
    [Route("api/analytics")]
    public class AnalyticsController : MainController
    {
        private readonly IQuizReportPerUserUseCase _useCase;

        public AnalyticsController(IHttpContextAccessor contextAccessor, IQuizReportPerUserUseCase useCase) : base(contextAccessor)
        {
            _useCase = useCase;
        }

        [HttpGet("generate-quiz-report-per-user/{quizUuid:guid}")]
        public async Task<IActionResult> GenerateQuizReport(Guid quizUuid)
        {
            var email = ReadEmailFromToken();
            var response = await _useCase.ExecuteAsync(new QuizReportPerUseRequest { QuizUuid = quizUuid, UserEmail = email});
            return Ok(response);
        }
    }
}