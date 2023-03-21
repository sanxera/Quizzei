using QZI.Quizzei.Application.Shared.Entities;

namespace QZI.Quizzei.Application.Shared.Repositories;

public interface IQuizInfoRepository : IRepository<QuizInformation>
{
    Task<QuizInformation> GetQuizInfoById(Guid id);
    Task<IEnumerable<QuizInformation>> GetQuizInfoByUserUuid(Guid userUuid);
    Task<IEnumerable<QuizInformation>> GetQuizInfoByDifferentUsers(Guid userUuid);
    Task<IEnumerable<QuizInformation>> GetQuizzesByTitle(string name);
    Task<IEnumerable<QuizInformation>> GetQuizzesByCategory(int categoryId);
}