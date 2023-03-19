using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Domain.Domains.Categories.Service.Abstractions;
using QZI.Quizzei.Domain.Domains.Categories.Service.Requests;

namespace QZI.Quizzei.API.Controllers;

//[Authorize]
[Route("api/categories")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    //[CustomAuthorize("Category", "Create")]
    [HttpPost("create-category")]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request)
    {
        var result = await _categoryService.CreateCategory(request);

        return Ok(result);
    }

    //[CustomAuthorize("Category", "Get")]
    [HttpGet("get-by-id/{categoryId:int}")]
    public async Task<IActionResult> GetCategoryById(int categoryId)
    {
        var result = await _categoryService.GetCategoryById(categoryId);

        return Ok(result);
    }


    //[CustomAuthorize("Category", "Get")]
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllCategories()
    {
        var result = await _categoryService.GetAllCategories();

        return Ok(result);
    }
}