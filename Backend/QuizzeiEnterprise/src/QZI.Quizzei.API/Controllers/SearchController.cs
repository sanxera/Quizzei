using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Domain.Domains.Search;

namespace QZI.Quizzei.API.Controllers;

[Route("api/search")]
public class SearchController : Controller
{
    private readonly ISearchService _searchService;

    public SearchController(ISearchService searchService)
    {
        _searchService = searchService;
    }

    [HttpPatch("{textToFind}")]
    public async Task<IActionResult> SearchByText(string textToFind)
    {
        var searchResponse = await _searchService.SearchByText(textToFind);
        return Ok(searchResponse);
    }
}