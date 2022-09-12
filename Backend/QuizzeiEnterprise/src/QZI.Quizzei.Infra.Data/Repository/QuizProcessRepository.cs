using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QZI.Quizzei.Domain.Domains.Quiz.Entities;
using QZI.Quizzei.Domain.Domains.Quiz.Repositories;
using QZI.Quizzei.Infra.Data.Repository.Base;

namespace QZI.Quizzei.Infra.Data.Repository
{
    public class QuizProcessRepository : RepositoryBase<QuizProcess>, IQuizProcessRepository
    {
        public QuizProcessRepository(QuizzeiContext context) : base(context)
        {
        }

        public async Task<QuizProcess> GetQuizInfoById(Guid id)
        {
            return await Context.QuizProcesses
                .FirstOrDefaultAsync(x => x.QuizProcessUuid == id);
        }
    }
}
