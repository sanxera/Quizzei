using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Domain.Domains.Category.Handlers.Commands;
using QZI.Quizzei.Domain.Domains.Category.Handlers.Requests;

namespace QZI.Quizzei.API.Controllers
{
    //[Authorize]
    [Route("api/categories")]
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[CustomAuthorize("Category", "Create")]
        [HttpPost("create-category")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request)
        {
            var command = new CreateCategoryCommand(request);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        //[CustomAuthorize("Category", "Get")]
        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetCategoryById([FromHeader] int categoryId)
        {
            var command = new GetCategoryByIdCommand(new GetCategoryByIdRequest {Id = categoryId});

            var result = await _mediator.Send(command);

            return Ok(result);
        }


        //[CustomAuthorize("Category", "Get")]
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllCategories()
        {
            var command = new GetAllCategoriesCommand(new GetAllCategoriesRequest());

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
