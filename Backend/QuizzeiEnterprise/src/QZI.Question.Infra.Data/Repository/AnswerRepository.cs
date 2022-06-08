using QZI.Question.Domain.Questions.Entities;
using QZI.Question.Domain.Questions.Repositories;
using QZI.Question.Infra.Data.Repository.Base;

namespace QZI.Question.Infra.Data.Repository
{
    public class AnswerRepository : RepositoryBase<Answer>, IAnswerRepository
    {
        public AnswerRepository(QuestionContext context) : base(context) { }
    }
}
