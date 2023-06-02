using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.QuizzesCategories.CreateCategory.Interfaces;
using QZI.Quizzei.Application.UseCases.QuizzesCategories.CreateCategory.Models.Request;

namespace QZI.Quizzei.API.Controllers.UseCases.QuizzesCategories.CreateCategory;

//[Authorize]
[Route("api/categories")]
public class CategoryController : Controller
{
    private readonly ICreateCategoryUseCase _useCase;

    public CategoryController(ICreateCategoryUseCase useCase)
    {
        _useCase = useCase;
    }

    //[CustomAuthorize("Category", "Create")]
    [HttpPost("create-category")]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request)
    {
        var result = await _useCase.ExecuteAsync(request);

        return Ok(result);
    }
}