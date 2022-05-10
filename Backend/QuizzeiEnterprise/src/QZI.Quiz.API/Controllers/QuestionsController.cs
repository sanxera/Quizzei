using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QZI.Core.Controllers;
using QZI.Quiz.Domain.Quiz.Handlers.Commands.Question;
using QZI.Quiz.Domain.Quiz.Handlers.Requests.Questions;

namespace QZI.Quiz.API.Controllers
{
    [Authorize]
    [Route("api/questions")]
    public class QuestionsController : MainController
    {
        private readonly IMediator _mediator;

        public QuestionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("create-questions-with-options")]
        public async Task<IActionResult> CreateQuestionsWithOptions([FromHeader] Guid quizInfoUuid, [FromBody]CreateQuestionsRequest request)
        {
            var command = new CreateQuestionsCommand(quizInfoUuid, request);

            var response = await _mediator.Send(command);

            return response.Created ? Ok(response) : BadRequest(response);
        }
    }
}
