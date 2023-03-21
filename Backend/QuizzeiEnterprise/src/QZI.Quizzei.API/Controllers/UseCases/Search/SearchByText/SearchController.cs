using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.Search.SearchByText.Interfaces;

namespace QZI.Quizzei.API.Controllers.UseCases.Search.SearchByText;

[Route("api/search")]
public class SearchController : Controller
{
    private readonly ISearchByTextUseCase _useCase;

    public SearchController(ISearchByTextUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpPatch("{textToFind}")]
    public async Task<IActionResult> SearchByText(string textToFind)
    {
        var searchResponse = await _useCase.ExecuteAsync(textToFind);
        return Ok(searchResponse);
    }
}