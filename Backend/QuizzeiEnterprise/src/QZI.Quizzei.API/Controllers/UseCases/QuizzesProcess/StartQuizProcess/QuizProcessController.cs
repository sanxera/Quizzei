#nullable enable
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.QuizzesProcess.StartQuizProcess.Interfaces;
using QZI.Quizzei.Application.UseCases.QuizzesProcess.StartQuizProcess.Models.Request;

namespace QZI.Quizzei.API.Controllers.UseCases.QuizzesProcess.StartQuizProcess;

[Route("api/quizzes-process")]
public class QuizProcessController : MainController
{
    private readonly IStartQuizProcessUseCase _useCase;

    public QuizProcessController(IStartQuizProcessUseCase useCase, IHttpContextAccessor contextAccessor) : base(contextAccessor)
    {
        _useCase = useCase;
    }

    [HttpPost("start-quiz/{quizInfo:guid}")]
    public async Task<IActionResult> StartQuizProcess(Guid quizInfo, [FromBody] AccessInformationRequest? accessInformation)
    {
        var email = ReadEmailFromToken();
        var result = await _useCase.ExecuteAsync(new StartQuizProcessRequest{EmailOwner = email, QuizUuid = quizInfo, AccessInformation = accessInformation});

        return Ok(result);
    }
}