using QZI.Quizzei.Application.UseCases.Search.SearchByText.Response;

namespace QZI.Quizzei.Application.UseCases.Search.SearchByText.Interfaces;

public interface ISearchByTextUseCase
{
    Task<SearchByTextResponse> ExecuteAsync(string text);
}