using QZI.Quiz.Domain.Quiz.Entities;
using QZI.Quiz.Domain.Quiz.Repositories;
using QZI.Quiz.Infra.Data.Data.Repository.Base;

namespace QZI.Quiz.Infra.Data.Data.Repository
{
    public class QuestionRepository : RepositoryBase<Question>, IQuestionRepository
    {
        public QuestionRepository(QuizContext context) : base(context) { }
    }
}
