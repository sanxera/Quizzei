using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.Files.GetFilesFromQuiz.Interfaces;
using QZI.Quizzei.Application.UseCases.Files.GetFilesFromQuiz.Models.Request;

namespace QZI.Quizzei.API.Controllers.UseCases.Files.GetFilesFromQuiz;

//[Authorize]
[Route("api/files")]
public class FilesController : Controller
{
    private readonly IGetFilesFromQuizUseCase _useCase;

    public FilesController(IGetFilesFromQuizUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpGet("get-files-from-quiz-information/{quizInfoUuid:guid}")]
    public async Task<IActionResult> GetFilesFromQuizInformation(Guid quizInfoUuid)
    {
        var response = await _useCase.ExecuteAsync(new GetFilesFromQuizInfoRequest{QuizInfoUuid = quizInfoUuid});

        return Ok(response);
    }
}