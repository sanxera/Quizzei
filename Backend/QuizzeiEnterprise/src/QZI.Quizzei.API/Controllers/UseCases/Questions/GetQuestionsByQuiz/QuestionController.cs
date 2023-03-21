using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using QZI.Quizzei.Application.UseCases.Questions.GetQuestionsByQuiz.Interfaces;
using QZI.Quizzei.Application.UseCases.Questions.GetQuestionsByQuiz.Models.Request;

namespace QZI.Quizzei.API.Controllers.UseCases.Questions.GetQuestionsByQuiz;

[Route("api/questions")]
public class QuestionController : Controller
{
    private readonly IGetQuestionsByQuizUseCase _useCase;

    public QuestionController(IGetQuestionsByQuizUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpGet("get-questions-by-quiz/{quizInfoUuid:guid}")]
    public async Task<IActionResult> GetQuestionsWithOptionsByQuiz(Guid quizInfoUuid)
    {
        var response = await _useCase.ExecuteAsync(new GetQuestionsByQuizRequest{QuizInfoUuid = quizInfoUuid});

        return Ok(response);
    }
}