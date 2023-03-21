using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.Answers.AnswerQuiz.Interfaces;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using QZI.Quizzei.Application.UseCases.Answers.AnswerQuiz.Models.Requests;

namespace QZI.Quizzei.API.Controllers.UseCases.Answers.AnswerQuiz
{
    [Route("api/answer")]
    public class AnswerController : Controller
    {
        private readonly IAnswerQuizUseCase _useCase;

        public AnswerController(IAnswerQuizUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpPost("answer-questions-by-process/{quizProcessUuid:guid}")]
        public async Task<IActionResult> AnswerQuestions(Guid quizProcessUuid, [FromBody] AnswerQuizRequest request)
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;

            var response = await _useCase.ExecuteAsync(email, quizProcessUuid, request);

            return Ok(response);
        }
    }
}
