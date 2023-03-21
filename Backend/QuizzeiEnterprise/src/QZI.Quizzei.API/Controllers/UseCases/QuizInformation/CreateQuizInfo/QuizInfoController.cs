using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.CreateQuizInfo.Interfaces;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.CreateQuizInfo.Models.Request;

namespace QZI.Quizzei.API.Controllers.UseCases.QuizInformation.CreateQuizInfo;

//[Authorize]
[Route("api/quizzes-info")]
public class QuizInfoController : Controller
{
    private readonly ICreateQuizInfoUseCase _useCase;

    public QuizInfoController(ICreateQuizInfoUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpPost("create-quiz-info")]
    public async Task<IActionResult> CreateQuizInfo([FromBody] CreateQuizInfoRequest request)
    {
        var email = User.FindFirst(ClaimTypes.Email)?.Value;
        var result = await _useCase.CreateQuizInformation(email, request);

        return Ok(result);
    }
}