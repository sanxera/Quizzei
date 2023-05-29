using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.QuestionsCategories.CreateQuestionCategory.Interfaces;
using QZI.Quizzei.Application.UseCases.QuestionsCategories.CreateQuestionCategory.Models.Request;

namespace QZI.Quizzei.API.Controllers.UseCases.QuestionsCategories.CreateQuestionCategory;

//[Authorize]
[Route("api/question-category")]
public class QuestionCategoryController : Controller
{
    private readonly ICreateQuestionCategoryUseCase _useCase;

    public QuestionCategoryController(ICreateQuestionCategoryUseCase useCase)
    {
        _useCase = useCase;
    }

    //[CustomAuthorize("Category", "Create")]
    [HttpPost("create")]
    public async Task<IActionResult> CreateQuestionCategory([FromBody] CreateQuestionCategoryRequest request)
    {
        var result = await _useCase.ExecuteAsync(request);

        return Ok(result);
    }
}