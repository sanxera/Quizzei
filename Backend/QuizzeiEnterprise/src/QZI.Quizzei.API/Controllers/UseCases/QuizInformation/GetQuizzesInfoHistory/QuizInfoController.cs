using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoHistory.Interfaces;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoHistory.Models.Request;

namespace QZI.Quizzei.API.Controllers.UseCases.QuizInformation.GetQuizzesInfoHistory;

//[Authorize]
[Route("api/quizzes-info")]
public class QuizInfoController : Controller
{
    private readonly IGetQuizzesInfoHistoryUseCase _useCase;

    public QuizInfoController(IGetQuizzesInfoHistoryUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpGet("get-quizzes-history-from-user")]
    public async Task<IActionResult> GetQuizzesHistoryFromUser()
    {
        var email = User.FindFirst(ClaimTypes.Email)?.Value;
        var result = await _useCase.ExecuteAsync(new GetQuizzesInfoHistoryRequest{Email = email});

        return Ok(result);
    }
}