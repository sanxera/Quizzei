using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.Files.GetDefaultImages.Interfaces;

namespace QZI.Quizzei.API.Controllers.UseCases.Files.GetDefaultImages;

//[Authorize]
[Route("api/files")]
public class FilesController : Controller
{
    private readonly IGetDefaultImagesUseCase _useCase;

    public FilesController(IGetDefaultImagesUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpGet("get-default-images")]
    public async Task<IActionResult> GetDefaultImages()
    {
        var response = await _useCase.ExecuteAsync();

        return Ok(response);
    }
}