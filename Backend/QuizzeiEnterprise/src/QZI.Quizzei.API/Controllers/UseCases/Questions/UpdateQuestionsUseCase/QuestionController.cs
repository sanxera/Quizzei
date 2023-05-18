using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.Questions.UpdateQuestionsUseCase.Interfaces;
using QZI.Quizzei.Application.UseCases.Questions.UpdateQuestionsUseCase.Models.Request;

namespace QZI.Quizzei.API.Controllers.UseCases.Questions.UpdateQuestionsUseCase;

//[Authorize]
[Route("api/questions")]
public class QuestionsController : Controller
{
    private readonly IUpdateQuestionsUseCase _useCase;

    public QuestionsController(IUpdateQuestionsUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpPatch("create-questions-with-options/{quizInfoUuid:guid}")]
    public async Task<IActionResult> CreateQuestionsWithOptions(Guid quizInfoUuid, [FromBody] UpdateQuestionsRequest request)
    {
        request.QuizInfoUuid = quizInfoUuid;

        await _useCase.ExecuteAsync(request);

        return Ok();
    }
}