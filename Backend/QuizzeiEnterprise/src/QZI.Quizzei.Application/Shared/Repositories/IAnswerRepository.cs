using QZI.Quizzei.Application.Shared.Entities;

namespace QZI.Quizzei.Application.Shared.Repositories;

public interface IAnswerRepository : IRepository<Answer>
{
    int GetCorrectAnswersCountByQuizProcess(Guid processUuid);
}