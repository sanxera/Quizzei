using QZI.Quiz.Domain.Quiz.Entities;
using QZI.Quiz.Domain.Quiz.Repositories;
using QZI.Quiz.Infra.Data.Data.Repository.Base;

namespace QZI.Quiz.Infra.Data.Data.Repository
{
    public class QuestionOptionRepository : RepositoryBase<QuestionOption>, IQuestionOptionRepository
    {
        public QuestionOptionRepository(QuizContext context) : base(context) { }
    }
}
