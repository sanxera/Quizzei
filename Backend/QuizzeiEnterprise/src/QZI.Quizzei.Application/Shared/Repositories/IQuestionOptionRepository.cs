using QZI.Quizzei.Application.Shared.Entities;

namespace QZI.Quizzei.Application.Shared.Repositories;

public interface IQuestionOptionRepository : IRepository<QuestionOption>
{
    Task<QuestionOption> GetQuestionOptionById(Guid id);
    Task<IList<QuestionOption>> GetQuestionOptionsByQuestionUuid(Guid questionUuid);
    void Delete(QuestionOption option);
}