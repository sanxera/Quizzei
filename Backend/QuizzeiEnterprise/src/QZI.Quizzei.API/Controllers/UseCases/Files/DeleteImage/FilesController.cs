using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.Files.DeleteImage.Interfaces;
using QZI.Quizzei.Application.UseCases.Files.DeleteImage.Models.Request;

namespace QZI.Quizzei.API.Controllers.UseCases.Files.DeleteImage;

//[Authorize]
[Route("api/files")]
public class FilesController : Controller
{
    private readonly IDeleteImageUseCase _useCase;

    public FilesController(IDeleteImageUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpPost("delete-image/{questionImageUuid:guid}")]
    public async Task<IActionResult> Upload(Guid questionImageUuid)
    {
        var response = await _useCase.ExecuteAsync(new DeleteImageRequest{QuestionImageUuid = questionImageUuid});

        return Ok(response);
    }
}