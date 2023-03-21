using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QZI.Quizzei.Application.Shared.Entities;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Infra.Data.Repository.Base;

namespace QZI.Quizzei.Infra.Data.Repository;

public class QuizProcessRepository : RepositoryBase<QuizProcess>, IQuizProcessRepository
{
    public QuizProcessRepository(QuizzeiContext context) : base(context)
    {
    }

    public async Task<QuizProcess> GetQuizProcessById(Guid id)
    {
        return await Context.QuizProcesses
            .FirstOrDefaultAsync(x => x.QuizProcessUuid == id);
    }

    public async Task<IList<QuizProcess>> GetQuizProcessByUser(Guid userUuid)
    {
        return await Context.QuizProcesses.Where(x => x.UserUuid == userUuid).ToListAsync();
    }
}