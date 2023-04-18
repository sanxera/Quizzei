using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.CreateQuizInfo.Interfaces;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.CreateQuizInfo.Models.Request;

namespace QZI.Quizzei.API.Controllers.UseCases.QuizzesInformation.CreateQuizInfo;

//[Authorize]
[Route("api/quizzes-info")]
public class QuizInfoController : MainController
{
    private readonly ICreateQuizInfoUseCase _useCase;

    public QuizInfoController(ICreateQuizInfoUseCase useCase, IHttpContextAccessor contextAccessor) : base(contextAccessor)
    {
        _useCase = useCase;
    }

    [HttpPost("create-quiz-info")]
    public async Task<IActionResult> CreateQuizInfo([FromBody] CreateQuizInfoRequest request)
    {
        var email = ReadEmailFromToken();
        var result = await _useCase.CreateQuizInformation(email, request);

        return Ok(result);
    }
}