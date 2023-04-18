using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.UpdateQuizInfo.Interfaces;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.UpdateQuizInfo.Models.Request;

namespace QZI.Quizzei.API.Controllers.UseCases.QuizzesInformation.UpdateQuizInfo;

//[Authorize]
[Route("api/quizzes-info")]
public class QuizInfoController : Controller
{
    private readonly IUpdateQuizInfoUseCase _useCase;

    public QuizInfoController(IUpdateQuizInfoUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpPatch("update-quiz-info/{quizInfoUuid:guid}")]
    public async Task<IActionResult> UpdateQuizInfo(Guid quizInfoUuid, [FromBody] UpdateQuizInfoRequest request)
    {
        await _useCase.ExecuteAsync(quizInfoUuid, request);

        return Ok(new {Status = "OK"});
    }
}