using System;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Identity.Authorization;
using QZI.Core.Controllers;
using QZI.Quiz.Domain.Quiz.Handlers.Commands.Quiz;
using QZI.Quiz.Domain.Quiz.Handlers.Requests.Quiz;

namespace QZI.Quiz.API.Controllers
{
    //[Authorize]
    [Route("api/quizzes")]
    public class QuizInfoController : MainController
    {
        private readonly IMediator _mediator;

        public QuizInfoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[CustomAuthorize("QuizInfo", "Create")]
        [HttpPost("create-quiz-info")]
        public async Task<IActionResult> CreateQuizInfo([FromBody] CreateQuizInfoRequest request)
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;

            var command = new CreateQuizInfoCommand(email, request);

            var response = await _mediator.Send(command);

            return response.CreatedQuizUuid == Guid.Empty ? Ok(response) : BadRequest(response);
        }
    }
}
