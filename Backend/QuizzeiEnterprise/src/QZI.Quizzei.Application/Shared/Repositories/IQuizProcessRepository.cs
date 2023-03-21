using QZI.Quizzei.Application.Shared.Entities;

namespace QZI.Quizzei.Application.Shared.Repositories;

public interface IQuizProcessRepository : IRepository<QuizProcess>
{
    Task<QuizProcess> GetQuizProcessById(Guid id);
    Task<IList<QuizProcess>> GetQuizProcessByUser(Guid userUuid);
}