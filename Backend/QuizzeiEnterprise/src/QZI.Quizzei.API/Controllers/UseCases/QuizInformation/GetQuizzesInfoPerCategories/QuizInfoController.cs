using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoPerCategories.Interfaces;

namespace QZI.Quizzei.API.Controllers.UseCases.QuizInformation.GetQuizzesInfoPerCategories;

//[Authorize]
[Route("api/quizzes-info")]
public class QuizInfoController : Controller
{
    private readonly IGetQuizzesInfoPerCategoriesUseCase _useCase;

    public QuizInfoController(IGetQuizzesInfoPerCategoriesUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpGet("get-quizzes-by-category-from-different-users")]
    public async Task<IActionResult> GetQuizzesInfoSeparateByCategoriesFromDifferentUsers()
    {
        var result = await _useCase.ExecuteAsync();

        return Ok(result);
    }
}