using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Domain.Domains.Questions.Services.Abstractions;
using QZI.Quizzei.Domain.Domains.Questions.Services.Requests;

namespace QZI.Quizzei.API.Controllers;

//[Authorize]
[Route("api/questions")]
public class QuestionsController : Controller
{
    private readonly IQuestionService _questionService;

    public QuestionsController(IQuestionService questionService)
    {
        _questionService = questionService;
    }

    [HttpPatch("create-questions-with-options/{quizInfoUuid:guid}")]
    public async Task<IActionResult> CreateQuestionsWithOptions(Guid quizInfoUuid, [FromBody] UpdateQuestionsWithOptionsRequest request)
    {
        await _questionService.UpdateQuestions(quizInfoUuid, request);

        return Ok();
    }

    [HttpGet("get-questions-by-quiz/{quizInfoUuid:guid}")]
    public async Task<IActionResult> GetQuestionsWithOptionsByQuiz(Guid quizInfoUuid)
    {
        var response = await _questionService.GetQuestionWithOptionsByQuizInfo(quizInfoUuid);

        return Ok(response);
    }
}