﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QZI.Quizzei.Application.Shared.Entities;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Infra.Data.Repository.Base;

namespace QZI.Quizzei.Infra.Data.Repository;

public class QuizRateRepository : RepositoryBase<QuizRate>, IQuizRateRepository
{
    public QuizRateRepository(QuizzeiContext context) : base(context)
    {
    }

    public async Task<IList<QuizRate>> GetRatesFromQuizInformation(Guid quizInformationUuid)
    {
        return await Context.QuizRates
            .Where(x => x.QuizInformationUuid == quizInformationUuid)
            .ToListAsync();
    }

    public async Task<int> GetRateFromQuizProcess(Guid quizProcessUuid)
    {
        var quizRate = await Context.QuizRates.FirstOrDefaultAsync(x => x.QuizProcessUuid == quizProcessUuid);

        return quizRate?.Rate ?? 0;
    }
}