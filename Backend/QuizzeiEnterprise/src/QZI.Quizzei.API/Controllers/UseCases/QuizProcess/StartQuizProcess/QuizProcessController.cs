using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.QuizzesProcess.StartQuizProcess.Interfaces;
using QZI.Quizzei.Application.UseCases.QuizzesProcess.StartQuizProcess.Models.Request;

namespace QZI.Quizzei.API.Controllers.UseCases.QuizProcess.StartQuizProcess;

[Route("api/quizzes-process")]
public class QuizProcessController : Controller
{
    private readonly IStartQuizProcessUseCase _useCase;

    public QuizProcessController(IStartQuizProcessUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpPost("start-quiz/{quizInfo:guid}")]
    public async Task<IActionResult> StartQuizProcess(Guid quizInfo)
    {
        var email = User.FindFirst(ClaimTypes.Email)?.Value;
        var result = await _useCase.ExecuteAsync(new StartQuizProcessRequest{EmailOwner = email, QuizUuid = quizInfo});

        return Ok(result);
    }
}