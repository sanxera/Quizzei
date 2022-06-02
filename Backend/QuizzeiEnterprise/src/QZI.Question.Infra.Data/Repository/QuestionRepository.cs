using QZI.Question.Domain.Questions.Repositories;
using QZI.Question.Infra.Data.Repository.Base;

namespace QZI.Question.Infra.Data.Repository
{
    public class QuestionRepository : RepositoryBase<Domain.Questions.Entities.Question>, IQuestionRepository
    {
        public QuestionRepository(QuestionContext context) : base(context) { }
    }
}
