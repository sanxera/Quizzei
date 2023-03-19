using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Domain.Domains.Questions.Services.Abstractions;
using QZI.Quizzei.Domain.Domains.Questions.Services.Requests;

namespace QZI.Quizzei.API.Controllers;

//[Authorize]
[Route("api/answer")]
public class AnswerController : Controller
{
    private readonly IAnswerService _answerService;

    public AnswerController(IAnswerService answerService)
    {
        _answerService = answerService;
    }

    [HttpPost("answer-questions-by-process/{quizProcessUuid:guid}")]
    public async Task<IActionResult> AnswerQuestions(Guid quizProcessUuid, [FromBody] AnswerQuestionRequest request)
    {
        var email = User.FindFirst(ClaimTypes.Email)?.Value;

        var response = await _answerService.AnswerQuestion(email, quizProcessUuid, request);

        return Ok(response);
    }
}