using System;
using System.Threading.Tasks;
using QZI.Quiz.Domain.Quiz.Entities;
using QZI.Quiz.Domain.Quiz.Repositories.Base;

namespace QZI.Quiz.Domain.Quiz.Repositories
{
    public interface IQuizInfoRepository : IRepository<QuizInfo>
    {
        Task<QuizInfo> GetQuizInfoById(Guid id);
    }
}
