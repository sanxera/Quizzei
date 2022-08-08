using System;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Domain.Domains.Quiz.Handlers.Commands.Process;
using QZI.Quizzei.Domain.Domains.Quiz.Handlers.Requests.Process;

namespace QZI.Quizzei.API.Controllers
{
    [Route("api/quizzes-process")]
    public class QuizProcessController : Controller
    {
        private readonly IMediator _mediator;

        public QuizProcessController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("start-quiz")]
        public async Task<IActionResult> StartQuizProcess([FromHeader] Guid quizInfo)
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var command = new StartQuizProcessCommand(email, new StartQuizProcessRequest{QuizUuid = quizInfo});

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
