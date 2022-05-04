using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Identity.Authorization;
using QZI.Core.Controllers;
using QZI.Quiz.Domain.Quiz.Handlers.Commands.Category;
using QZI.Quiz.Domain.Quiz.Handlers.Requests.Category;

namespace QZI.Quiz.API.Controllers
{
    [Authorize]
    [Route("api/categories")]
    public class CategoryController : MainController
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [CustomAuthorize("Category", "Create")]
        [HttpPost("create-category")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request)
        {
            var command = new CreateCategoryCommand(request);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [CustomAuthorize("Category", "Get")]
        [HttpPost("get-all")]
        public async Task<IActionResult> GetAllCategories()
        {
            var command = new GetAllCategoriesCommand(new GetAllCategoriesRequest());

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
