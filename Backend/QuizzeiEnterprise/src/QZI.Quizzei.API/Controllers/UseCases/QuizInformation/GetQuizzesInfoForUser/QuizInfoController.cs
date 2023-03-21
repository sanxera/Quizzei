using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoForUser.Interfaces;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoForUser.Models.Request;

namespace QZI.Quizzei.API.Controllers.UseCases.QuizInformation.GetQuizzesInfoForUser;

//[Authorize]
[Route("api/quizzes-info")]
public class QuizInfoController : Controller
{
    private readonly IGetQuizzesInfoForUserUseCase _useCase;

    public QuizInfoController(IGetQuizzesInfoForUserUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpGet("get-all-by-different-users")]
    public async Task<IActionResult> GetQuizzesInfoByDifferentUsers()
    {
        var email = User.FindFirst(ClaimTypes.Email)?.Value;
        var result = await _useCase.ExecuteAsync(new GetQuizzesInfoForUserRequest{EmailOwner = email});

        return Ok(result);
    }
}