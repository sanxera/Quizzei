using System;
using System.Threading.Tasks;
using QZI.Quizzei.Domain.Abstractions;
using QZI.Quizzei.Domain.Domains.Questions.Entities;

namespace QZI.Quizzei.Domain.Domains.Questions.Repositories
{
    public interface IQuestionOptionRepository : IRepository<QuestionOption>
    {
        Task<QuestionOption> GetQuestionOptionById(Guid id);
        void Delete(QuestionOption option);
    }
}
