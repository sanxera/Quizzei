using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.Files.UploadFile.Interfaces;

namespace QZI.Quizzei.API.Controllers.UseCases.Files.UploadFile;

//[Authorize]
[Route("api/files")]
public class FilesController : Controller
{
    private readonly IUploadFileUseCase _useCase;

    public FilesController(IUploadFileUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpPost("upload/{quizInfoUuid:guid}")]
    public async Task<IActionResult> Upload(Guid quizInfoUuid, IFormFile file)
    {
        var fileName = file.FileName;
        var stream = file.OpenReadStream();

        var response = await _useCase.ExecuteAsync(quizInfoUuid, fileName, stream);

        return Ok(response);
    }
}