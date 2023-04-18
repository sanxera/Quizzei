using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoForUser.Interfaces;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoForUser.Models.Request;

namespace QZI.Quizzei.API.Controllers.UseCases.QuizzesInformation.GetQuizzesInfoForUser;

//[Authorize]
[Route("api/quizzes-info")]
public class QuizInfoController : MainController
{
    private readonly IGetQuizzesInfoForUserUseCase _useCase;

    public QuizInfoController(IGetQuizzesInfoForUserUseCase useCase, IHttpContextAccessor contextAccessor) : base(contextAccessor)
    {
        _useCase = useCase;
    }

    [HttpGet("get-all-by-different-users")]
    public async Task<IActionResult> GetQuizzesInfoByDifferentUsers()
    {
        var email = ReadEmailFromToken();
        var result = await _useCase.ExecuteAsync(new GetQuizzesInfoForUserRequest{EmailOwner = email});

        return Ok(result);
    }
}