using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QZI.Quiz.Domain.Quiz.Entities;
using QZI.Quiz.Domain.Quiz.Repositories;
using QZI.Quiz.Infra.Data.Data.Repository.Base;

namespace QZI.Quiz.Infra.Data.Data.Repository
{
    public class QuizInfoRepository : RepositoryBase<QuizInfo>, IQuizInfoRepository
    {
        public QuizInfoRepository(QuizContext context) : base(context) { }

        public async Task<QuizInfo> GetQuizInfoById(Guid id)
        {
            return await Context.QuizzesInfos
                .FirstOrDefaultAsync(x => x.QuizInfoUuid == id);
        }
    }
}
