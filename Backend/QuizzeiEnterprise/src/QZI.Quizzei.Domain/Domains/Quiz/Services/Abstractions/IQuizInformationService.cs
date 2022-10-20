using System.Threading.Tasks;
using QZI.Quizzei.Domain.Domains.Quiz.Services.Requests.Information;
using QZI.Quizzei.Domain.Domains.Quiz.Services.Response.Information;

namespace QZI.Quizzei.Domain.Domains.Quiz.Services.Abstractions
{
    public interface IQuizInformationService
    {
        Task<CreateQuizInfoResponse> CreateQuizInformation(string emailOwner, CreateQuizInfoRequest request);
        Task<GetQuizzesResponse> GetQuizzesInformationByUser(string emailOwner);
        Task<GetQuizzesResponse> GetQuizzesInformationByDifferentUser(string emailOwner);
        Task<GetQuizzesByCategoryResponse> GetQuizzesInfoSeparateByCategoriesFromDifferentUsers(string emailOwner);
    }
}
