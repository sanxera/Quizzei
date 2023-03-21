using QZI.Quizzei.Application.Shared.Entities;

namespace QZI.Quizzei.Application.Shared.Repositories;

public interface IQuestionOptionRepository : IRepository<QuestionOption>
{
    Task<QuestionOption> GetQuestionOptionById(Guid id);
    void Delete(QuestionOption option);
}