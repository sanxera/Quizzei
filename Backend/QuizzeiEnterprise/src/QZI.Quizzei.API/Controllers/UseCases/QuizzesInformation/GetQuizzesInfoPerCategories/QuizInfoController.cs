using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoPerCategories.Interfaces;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoPerCategories.Models.Request;

namespace QZI.Quizzei.API.Controllers.UseCases.QuizzesInformation.GetQuizzesInfoPerCategories;

//[Authorize]
[Route("api/quizzes-info")]
public class QuizInfoController : MainController
{
    private readonly IGetQuizzesInfoPerCategoriesUseCase _useCase;


    public QuizInfoController(IGetQuizzesInfoPerCategoriesUseCase useCase, IHttpContextAccessor contextAccessor) : base(contextAccessor)
    {
        _useCase = useCase;
    }

    [HttpGet("get-quizzes-by-category-from-different-users")]
    public async Task<IActionResult> GetQuizzesInfoSeparateByCategoriesFromDifferentUsers()
    {
        var email = ReadEmailFromToken();

        var result = await _useCase.ExecuteAsync(new GetQuizzesInfoPerCategoriesRequest{EmailOwner = email});

        return Ok(result);
    }
}