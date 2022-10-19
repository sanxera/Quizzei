using System.Collections.Generic;
using System.Threading.Tasks;
using QZI.Quizzei.Domain.Domains.Search.Response;

namespace QZI.Quizzei.Domain.Domains.Search
{
    public interface ISearchService
    {
        Task<IEnumerable<SearchResponse>> SearchByText(string text);
    }
}
