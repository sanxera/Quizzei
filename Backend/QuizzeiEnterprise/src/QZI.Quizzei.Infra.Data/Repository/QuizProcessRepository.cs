using QZI.Quizzei.Domain.Domains.Quiz.Entities;
using QZI.Quizzei.Domain.Domains.Quiz.Repositories;
using QZI.Quizzei.Infra.Data.Repository.Base;

namespace QZI.Quizzei.Infra.Data.Repository
{
    public class QuizProcessRepository : RepositoryBase<QuizProcess>, IQuizProcessRepository
    {
        public QuizProcessRepository(QuizzeiContext context) : base(context)
        {
        }
    }
}
