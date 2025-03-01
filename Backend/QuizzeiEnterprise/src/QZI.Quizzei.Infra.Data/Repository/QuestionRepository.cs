﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QZI.Quizzei.Application.Shared.Entities;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Infra.Data.Repository.Base;

namespace QZI.Quizzei.Infra.Data.Repository;

public class QuestionRepository : RepositoryBase<Question>, IQuestionRepository
{
    public QuestionRepository(QuizzeiContext context) : base(context) { }

    public async Task<Question?> GetQuestionById(Guid id)
    {
        return await Context.Questions
            .Include(x => x.Options)
            .Include(i => i.Images)
            .FirstOrDefaultAsync(x => x.QuestionUuid == id);
    }

    public async Task<IList<Question>> GetQuestionsByQuizInfo(Guid quizInfoUuid)
    {
        return await Context.Questions
            .Include(x => x.Options)
            .Include(i => i.Images)
            .Where(x => x.QuizInfoUuid == quizInfoUuid)
            .ToListAsync();
    }

    public void Delete(Question? question)
    {
        Context.Questions.Remove(question);
    }
}