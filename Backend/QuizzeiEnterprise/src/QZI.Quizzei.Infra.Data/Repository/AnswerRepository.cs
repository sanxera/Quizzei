using System;
using System.Linq;
using QZI.Quizzei.Domain.Domains.Questions.Entities;
using QZI.Quizzei.Domain.Domains.Questions.Repositories;
using QZI.Quizzei.Infra.Data.Repository.Base;

namespace QZI.Quizzei.Infra.Data.Repository
{
    public class AnswerRepository : RepositoryBase<Answer>, IAnswerRepository
    {
        public AnswerRepository(QuizzeiContext context) : base(context) { }

        public int GetCorrectAnswersCountByQuizProcess(Guid processUuid)
        {
            return Context.Answers.Count(x => x.QuizProcessUuid == processUuid && x.CorrectAnswer);
        }
    }
}
