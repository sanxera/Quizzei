using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.Files.ReadPdf.Interfaces;

namespace QZI.Quizzei.API.Controllers.UseCases.Files.ReadPdf;

[Route("api/files")]
public class FilesController : Controller
{
    private readonly IReadPdfUseCase _useCase;

    public FilesController(IReadPdfUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpPost("read-pdf")]
    public async Task<IActionResult> ReadQuestionsFromPdf(IFormFile file)
    {
        var fileName = file.FileName;
        var stream = file.OpenReadStream();

        var response = await _useCase.ExecuteAsync(stream, fileName);

        return Ok(response);
    }
}