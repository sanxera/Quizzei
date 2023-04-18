using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.QuizzesProcess.RatingQuiz.Interfaces;
using QZI.Quizzei.Application.UseCases.QuizzesProcess.RatingQuiz.Models.Request;

namespace QZI.Quizzei.API.Controllers.UseCases.QuizzesProcess.RatingQuiz;

[Route("api/quizzes-process")]
public class QuizProcessController : Controller
{
    private readonly IRatingQuizUseCase _useCase;

    public QuizProcessController(IRatingQuizUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpPost("rating-quiz/{quizProcessUuid:guid}")]
    public async Task<IActionResult> RatingQuiz(Guid quizProcessUuid, int rate)
    {
        await _useCase.ExecuteAsync(new RatingQuizRequest{QuizInformationUuid = quizProcessUuid, RatePoints = rate});

        return Ok();
    }
}