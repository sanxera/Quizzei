using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.Categories.GetCategoryById.Interfaces;
using QZI.Quizzei.Application.UseCases.Categories.GetCategoryById.Models.Request;

namespace QZI.Quizzei.API.Controllers.UseCases.Category.GetCategoryById;

//[Authorize]
[Route("api/categories")]
public class CategoryController : Controller
{
    private readonly IGetCategoryByIdUseCase _useCase;

    public CategoryController(IGetCategoryByIdUseCase useCase)
    {
        _useCase = useCase;
    }

    //[CustomAuthorize("Category", "Get")]
    [HttpGet("get-by-id/{categoryId:int}")]
    public async Task<IActionResult> GetCategoryById(int categoryId)
    {
        var result = await _useCase.ExecuteAsync(new GetCategoryByIdRequest {Id = categoryId});

        return Ok(result);
    }
}