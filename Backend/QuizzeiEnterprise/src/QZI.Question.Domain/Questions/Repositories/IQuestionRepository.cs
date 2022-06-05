using System;
using System.Threading.Tasks;
using QZI.Question.Domain.Questions.Repositories.Base;

namespace QZI.Question.Domain.Questions.Repositories
{
    public interface IQuestionRepository : IRepository<Entities.Question>
    {
        Task<Entities.Question> GetQuestionById(Guid id);
    }
}
