﻿using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QZI.Core.Controllers;
using QZI.Quiz.Domain.Quiz.Handlers.Commands.Process;
using QZI.Quiz.Domain.Quiz.Handlers.Requests.Process;

namespace QZI.Quiz.API.Controllers
{
    [Route("api/quizzes-process")]
    public class QuizProcessController : MainController
    {
        private readonly IMediator _mediator;

        public QuizProcessController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("start-quiz")]
        public async Task<IActionResult> StartQuizProcess([FromBody] StartQuizProcessRequest request)
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var command = new StartQuizProcessCommand(email, request);

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
