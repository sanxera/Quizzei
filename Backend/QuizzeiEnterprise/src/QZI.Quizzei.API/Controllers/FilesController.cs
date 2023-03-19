using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Domain.Domains.Files.Abstractions;
using QZI.Quizzei.Domain.Domains.Quiz.Services.Abstractions;

namespace QZI.Quizzei.API.Controllers;

//[Authorize]
[Route("api/files")]
public class FilesController : Controller
{
    private readonly IFilesService _filesService;
    private readonly IReadPdfService _pdfService;

    public FilesController(IFilesService filesService, IReadPdfService pdfService)
    {
        _filesService = filesService;
        _pdfService = pdfService;
    }  

    [HttpPost("upload/{quizInfoUuid:guid}")]
    public async Task<IActionResult> Upload(Guid quizInfoUuid, IFormFile file)
    {
        var fileName = file.FileName;
        var stream = file.OpenReadStream();

        var response = await _filesService.UploadFileToBucket(quizInfoUuid, fileName, stream);

        return Ok(response);
    }

    [HttpGet("get-files-from-quiz-information/{quizInfoUuid:guid}")]
    public async Task<IActionResult> GetFilesFromQuizInformation(Guid quizInfoUuid)
    {
        var response = await _filesService.GetFilesFromQuizInfo(quizInfoUuid);

        return Ok(response);
    }

    [HttpGet("get-all-files")]
    public async Task<IActionResult> GetAllFiles()
    {
        var response = await _filesService.GetRandomFiles();

        return Ok(response);
    }

    [HttpGet("download-file/{fileUuid:guid}")]
    public async Task<IActionResult> DownloadFile(Guid fileUuid)
    {
        var response = await _filesService.DownloadFileFromS3(fileUuid);

        return File(response.FileStream, "application/pdf", response.FileName);
    }

    [HttpPost("read-pdf")]
    public async Task<IActionResult> ReadQuestionsFromPdf(IFormFile file)
    {
        var fileName = file.FileName;
        var stream = file.OpenReadStream();

        var response = await _pdfService.ExecuteAsync(stream, fileName, CancellationToken.None);

        return Ok(response);
    }
}