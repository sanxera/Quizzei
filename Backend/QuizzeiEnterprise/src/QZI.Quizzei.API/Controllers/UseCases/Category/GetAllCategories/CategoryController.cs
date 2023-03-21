using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.Categories.GetAllCategories.Interfaces;


namespace QZI.Quizzei.API.Controllers.UseCases.Category.GetAllCategories;

//[Authorize]
[Route("api/categories")]
public class CategoryController : Controller
{
    private readonly IGetAllCategoriesUseCase _useCase;

    public CategoryController(IGetAllCategoriesUseCase useCase)
    {
        _useCase = useCase;
    }

    //[CustomAuthorize("Category", "Get")]
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllCategories()
    {
        var result = await _useCase.ExecuteAsync();

        return Ok(result);
    }
}