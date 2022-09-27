using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Domain.Domains.Quiz.Services.Abstractions;

namespace QZI.Quizzei.API.Controllers
{
    [Route("api/quizzes-process")]
    public class QuizProcessController : Controller
    {
        private readonly IQuizProcessService _quizProcessService;

        public QuizProcessController(IQuizProcessService quizProcessService)
        {
            _quizProcessService = quizProcessService;
        }

        [HttpPost("start-quiz/{quizInfo:guid}")]
        public async Task<IActionResult> StartQuizProcess(Guid quizInfo)
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var result = await _quizProcessService.StartQuizProcess(email, quizInfo);

            return Ok(result);
        }

        [HttpPost("avaliate-quiz/{quizProcessUuid:guid}")]
        public async Task<IActionResult> RatingQuiz(Guid quizProcessUuid, int rate)
        {
            var result = await _quizProcessService.RatingQuiz(quizProcessUuid, rate);

            return Ok(result);
        }
    }
}
