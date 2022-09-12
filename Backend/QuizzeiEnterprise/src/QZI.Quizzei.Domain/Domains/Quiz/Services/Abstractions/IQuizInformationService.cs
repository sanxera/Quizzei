using System.Threading.Tasks;
using QZI.Quizzei.Domain.Domains.Quiz.Services.Requests.Information;
using QZI.Quizzei.Domain.Domains.Quiz.Services.Response.Information;

namespace QZI.Quizzei.Domain.Domains.Quiz.Services.Abstractions
{
    public interface IQuizInformationService
    {
        Task<CreateQuizInfoResponse> CreateQuizInformation(string emailOwner, CreateQuizInfoRequest request);
        Task<GetQuizzesInfoByUserResponse> GetQuizzesInformationByUser(string emailOwner);
        Task<GetQuizzesInfoByDifferentUsersResponse> GetQuizzesInformationByDifferentUser(string emailOwner);
    }
}
