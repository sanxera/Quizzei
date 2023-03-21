using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.Files.GetRandomFiles.Interfaces;

namespace QZI.Quizzei.API.Controllers.UseCases.Files.GetRandomFiles;

//[Authorize]
[Route("api/files")]
public class FilesController : Controller
{
    private readonly IGetRandomFilesUseCase _useCase;

    public FilesController(IGetRandomFilesUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpGet("get-all-files")]
    public async Task<IActionResult> GetAllFiles()
    {
        var response = await _useCase.ExecuteAsync();

        return Ok(response);
    }
}