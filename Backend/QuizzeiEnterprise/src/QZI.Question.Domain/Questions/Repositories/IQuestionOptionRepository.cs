using System;
using System.Threading.Tasks;
using QZI.Question.Domain.Questions.Entities;
using QZI.Question.Domain.Questions.Repositories.Base;

namespace QZI.Question.Domain.Questions.Repositories
{
    public interface IQuestionOptionRepository : IRepository<QuestionOption>
    {
        Task<QuestionOption> GetQuestionOptionById(Guid id);
    }
}
