using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QZI.Core.Controllers;
using QZI.Quiz.Domain.Quiz.Handlers.Commands;
using QZI.Quiz.Domain.Quiz.Handlers.Requests;

namespace QZI.Quiz.API.Controllers
{
    [Route("api/quizzes")]
    public class QuizInfoController : MainController
    {
        private readonly IMediator _mediator;

        public QuizInfoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-quiz-info")]
        public async Task<IActionResult> CreateQuizInfo([FromBody] CreatCategoryRequest request)
        {
            var command = new CreateQuizInfoCommand(request);

            var response = await _mediator.Send(command);

            return response.Created ? Ok(response) : BadRequest(response);
        }
    }
}
