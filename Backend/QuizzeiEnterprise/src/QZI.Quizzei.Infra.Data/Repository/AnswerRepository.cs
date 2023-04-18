using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QZI.Quizzei.Application.Shared.Entities;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Infra.Data.Repository.Base;

namespace QZI.Quizzei.Infra.Data.Repository;

public class AnswerRepository : RepositoryBase<Answer>, IAnswerRepository
{
    public AnswerRepository(QuizzeiContext context) : base(context) { }

    public int GetCorrectAnswersCountByQuizProcess(Guid processUuid)
    {
        return Context.Answers.Count(x => x.QuizProcessUuid == processUuid && x.CorrectAnswer);
    }

    public async Task<IList<Answer>> GetAnswersByQuestion(Guid questionUuid)
    {
        return await Context.Answers.Where(x => x.QuestionUuid == questionUuid).ToListAsync();
    }

    public async Task<IList<Answer>> GetAnswersByQuestionAndProcess(Guid questionUuid, Guid quizProcessUuid)
    {
        return await Context.Answers.Where(x => x.QuestionUuid == questionUuid && x.QuizProcessUuid == quizProcessUuid).ToListAsync();
    }
}