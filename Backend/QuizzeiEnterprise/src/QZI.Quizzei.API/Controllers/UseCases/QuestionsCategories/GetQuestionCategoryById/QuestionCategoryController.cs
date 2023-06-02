using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.QuestionsCategories.GetQuestionCategoryById.Interfaces;
using QZI.Quizzei.Application.UseCases.QuestionsCategories.GetQuestionCategoryById.Models.Request;

namespace QZI.Quizzei.API.Controllers.UseCases.QuestionsCategories.GetQuestionCategoryById;

//[Authorize]
[Route("api/question-category")]
public class QuestionCategoryController : Controller
{
    private readonly IGetQuestionCategoryByIdUseCase _useCase;

    public QuestionCategoryController(IGetQuestionCategoryByIdUseCase useCase)
    {
        _useCase = useCase;
    }

    //[CustomAuthorize("Category", "Get")]
    [HttpGet("get-by-id/{categoryId:int}")]
    public async Task<IActionResult> GetCategoryById(int categoryId)
    {
        var result = await _useCase.ExecuteAsync(new GetQuestionCategoryByIdRequest {Id = categoryId});

        return Ok(result);
    }
}