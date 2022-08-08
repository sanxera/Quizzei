using System;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QZI.Question.Domain.Questions.Handlers.Commands;
using QZI.Question.Domain.Questions.Handlers.Requests;

namespace QZI.Question.API.Controllers
{
    [Authorize]
    [Route("api/questions")]
    public class QuestionsController : Controller
    {
        private readonly IMediator _mediator;

        public QuestionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("create-questions-with-options")]
        public async Task<IActionResult> CreateQuestionsWithOptions([FromHeader] Guid quizInfoUuid, [FromBody] CreateQuestionsRequest request)
        {
            var command = new CreateQuestionsCommand(quizInfoUuid, request);

            var response = await _mediator.Send(command);

            return response.Created ? Ok(response) : BadRequest(response);
        }

        [AllowAnonymous]
        [HttpGet("get-questions-by-quiz")]
        public async Task<IActionResult> GetQuestionsWithOptionsByQuiz([FromHeader] Guid quizInfoUuid)
        {
            var command = new GetQuestionsWithOptionsByQuizCommand(new GetQuestionsWithOptionsByQuizRequest {QuizInfoUuid = quizInfoUuid});

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("answer-questions")]
        public async Task<IActionResult> AnswerQuestions(AnswerQuestionRequest request)
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;

            var command = new AnswerQuestionCommand(email, request);

            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
