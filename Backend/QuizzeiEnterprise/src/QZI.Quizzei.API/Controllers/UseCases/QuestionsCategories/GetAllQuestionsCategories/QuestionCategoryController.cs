using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.QuestionsCategories.GetAllQuestionsCategories.Interfaces;

namespace QZI.Quizzei.API.Controllers.UseCases.QuestionsCategories.GetAllQuestionsCategories;

//[Authorize]
[Route("api/question-category")]
public class QuestionCategoryController : Controller
{
    private readonly IGetAllQuestionsCategoriesUseCase _useCase;

    public QuestionCategoryController(IGetAllQuestionsCategoriesUseCase useCase)
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