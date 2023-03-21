using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.Files.DownloadFile.Interfaces;
using QZI.Quizzei.Application.UseCases.Files.DownloadFile.Models.Request;

namespace QZI.Quizzei.API.Controllers.UseCases.Files.DownloadFile;

//[Authorize]
[Route("api/files")]
public class FilesController : Controller
{
    private readonly IDownloadFileUseCase _useCase;

    public FilesController(IDownloadFileUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpGet("download-file/{fileUuid:guid}")]
    public async Task<IActionResult> DownloadFile(Guid fileUuid)
    {
        var response = await _useCase.ExecuteAsync(new DownloadFileRequest{FileUuid = fileUuid});

        return File(response.FileStream, "application/pdf", response.FileName);
    }
}