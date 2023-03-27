using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoFiles.Interfaces;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoFiles.Models.Request;

namespace QZI.Quizzei.API.Controllers.UseCases.QuizInformation.GetQuizzesInfoFiles;

//[Authorize]
[Route("api/files")]
public class FilesController : Controller
{
    private readonly IGetQuizzesInfoFilesUseCase _useCase;

    public FilesController(IGetQuizzesInfoFilesUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpGet("get-files-from-quiz-information/{quizInfoUuid:guid}")]
    public async Task<IActionResult> GetQuizzesInfoFiles(Guid quizInfoUuid)
    {
        var response = await _useCase.ExecuteAsync(new GetFilesFromQuizInfoRequest { QuizInfoUuid = quizInfoUuid });

        return Ok(response);
    }
}