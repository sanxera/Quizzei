using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QZI.Quizzei.Application.Shared.Entities;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Infra.Data.Repository.Base;

namespace QZI.Quizzei.Infra.Data.Repository;

public class QuestionOptionRepository : RepositoryBase<QuestionOption>, IQuestionOptionRepository
{
    public QuestionOptionRepository(QuizzeiContext context) : base(context) { }

    public async Task<QuestionOption> GetQuestionOptionById(Guid id)
    {
        return await Context.Options.FirstOrDefaultAsync(x => x.QuestionOptionUuid == id);
    }

    public void Delete(QuestionOption option)
    {
        Context.Options.Remove(option);
    }
}