using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoHistory.Interfaces;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoHistory.Models.Request;

namespace QZI.Quizzei.API.Controllers.UseCases.QuizzesInformation.GetQuizzesInfoHistory;

//[Authorize]
[Route("api/quizzes-info")]
public class QuizInfoController : MainController
{
    private readonly IGetQuizzesInfoHistoryUseCase _useCase;

    public QuizInfoController(IGetQuizzesInfoHistoryUseCase useCase, IHttpContextAccessor contextAccessor) : base(contextAccessor)
    {
        _useCase = useCase;
    }

    [HttpGet("get-quizzes-history-from-user")]
    public async Task<IActionResult> GetQuizzesHistoryFromUser()
    {
        var email = ReadEmailFromToken();
        var result = await _useCase.ExecuteAsync(new GetQuizzesInfoHistoryRequest{Email = email});

        return Ok(result);
    }
}