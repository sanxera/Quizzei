using QZI.Quiz.Domain.Quiz.Entities;
using QZI.Quiz.Domain.Quiz.Repositories;
using QZI.Quiz.Infra.Data.Data.Repository.Base;

namespace QZI.Quiz.Infra.Data.Data.Repository
{
    public class QuizProcessRepository : RepositoryBase<QuizProcess>, IQuizProcessRepository
    {
        public QuizProcessRepository(QuizContext context) : base(context)
        {
        }
    }
}
