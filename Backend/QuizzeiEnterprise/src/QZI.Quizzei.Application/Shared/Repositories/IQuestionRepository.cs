using QZI.Quizzei.Application.Shared.Entities;

namespace QZI.Quizzei.Application.Shared.Repositories;

public interface IQuestionRepository : IRepository<Question>
{
    Task<Question?> GetQuestionById(Guid id);
    Task<IList<Question>> GetQuestionsByQuizInfo(Guid quizInfoUuid);
    void Delete(Question? question);
}