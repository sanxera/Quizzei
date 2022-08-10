using System;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Domain.Domains.Quiz.Handlers.Commands.Information;
using QZI.Quizzei.Domain.Domains.Quiz.Handlers.Requests.Information;

namespace QZI.Quizzei.API.Controllers
{
    //[Authorize]
    [Route("api/quizzes-info")]
    public class QuizInfoController : Controller
    {
        private readonly IMediator _mediator;

        public QuizInfoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[CustomAuthorize("QuizInformation", "Create")]
        [HttpPost("create-quiz-info")]
        public async Task<IActionResult> CreateQuizInfo([FromBody] CreateQuizInfoRequest request)
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;

            var command = new CreateQuizInfoCommand(email, request);

            var response = await _mediator.Send(command);

            return response.CreatedQuizUuid != Guid.Empty ? Ok(response) : BadRequest(response);
        }

        [HttpGet("get-all-by-user")]
        public async Task<IActionResult> GetQuizzesInfoByUser()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var command = new GetQuizzesInfoByUserCommand(new GetQuizzesInfoByUserRequest {UserEmail = email});

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpGet("get-all-by-different-users")]
        public async Task<IActionResult> GetQuizzesInfo()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var command = new GetQuizzesInfoByDifferentUsersCommand(new GetQuizzesInfoByDifferentUsersRequest{ UserEmail = email });

            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
