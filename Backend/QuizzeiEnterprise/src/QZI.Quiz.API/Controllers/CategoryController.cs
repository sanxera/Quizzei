using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QZI.Core.Controllers;
using QZI.Quiz.Domain.Quiz.Handlers.Commands;
using QZI.Quiz.Domain.Quiz.Handlers.Requests;

namespace QZI.Quiz.API.Controllers
{
    [Route("api/categories")]
    public class CategoryController : MainController
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-category")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request)
        {
            var command = new CreateCategoryCommand(request);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost("get-all")]
        public async Task<IActionResult> GetAllCategories()
        {
            var command = new GetAllCategoriesCommand(new GetAllCategoriesRequest());

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
