using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QZI.Quizzei.Domain.Abstractions;
using QZI.Quizzei.Domain.Domains.Questions.Entities;

namespace QZI.Quizzei.Domain.Domains.Questions.Repositories
{
    public interface IQuestionRepository : IRepository<Question>
    {
        Task<Question> GetQuestionById(Guid id);
        Task<IList<Question>> GetQuestionsByQuizInfo(Guid quizInfoUuid);
    }
}
