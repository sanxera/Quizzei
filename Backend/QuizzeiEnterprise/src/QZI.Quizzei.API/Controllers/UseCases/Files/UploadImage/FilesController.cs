using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.Files.UploadImage.Interfaces;
using QZI.Quizzei.Application.UseCases.Files.UploadImage.Models.Request;

namespace QZI.Quizzei.API.Controllers.UseCases.Files.UploadImage;

//[Authorize]
[Route("api/files")]
public class FilesController : Controller
{
    private readonly IUploadImageUseCase _useCase;

    public FilesController(IUploadImageUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpPost("upload-image")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        var fileName = file.FileName;
        var fileContentType = file.ContentType;
        var stream = file.OpenReadStream();

        var response = await _useCase.ExecuteAsync(new UploadImageRequest {ContentType = fileContentType, FileName = fileName, FileStream = stream});

        return Ok(response);
    }
}