using QZI.Quizzei.Application.Shared.Entities;

namespace QZI.Quizzei.Application.Shared.Repositories;

public interface IQuizRateRepository : IRepository<QuizRate>
{
    Task<IList<QuizRate>> GetRatesFromQuizInformation(Guid quizInformationUuid);
    Task<int> GetRateFromQuizProcess(Guid quizProcessUuid);
}