using QZI.Quizzei.Application.Shared.Entities;

namespace QZI.Quizzei.Application.Shared.Repositories;

public interface IAnswerRepository : IRepository<Answer>
{
    int GetCorrectAnswersCountByQuizProcess(Guid processUuid);
    Task<IList<Answer>> GetAnswersByQuestion(Guid questionUuid);
    Task<IList<Answer>> GetAnswersByQuestionAndProcess(Guid questionUuid, Guid quizProcessUuid);
}