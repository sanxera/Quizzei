using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.QuizzesProcess.GetUsersByQuizzes.Interfaces;
using QZI.Quizzei.Application.UseCases.QuizzesProcess.GetUsersByQuizzes.Models.Request;

namespace QZI.Quizzei.API.Controllers.UseCases.QuizzesProcess.GetUsersByQuizzes;

[Route("api/quizzes-process")]
public class QuizProcessController : Controller
{
    private readonly IGetUsersByQuizzesUseCase _useCase;

    public QuizProcessController(IGetUsersByQuizzesUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpPost("get-users-by-quiz/{quizInfoUuid:guid}")]
    public async Task<IActionResult> GetUsersByQuizzes(Guid quizInfoUuid)
    {
        var response = await _useCase.ExecuteAsync(new GetUsersByQuizzesRequest{QuizInfoUuid = quizInfoUuid });

        return Ok(response);
    }
}