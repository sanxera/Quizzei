using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<QuizInfo>> GetQuizInfoByUserUuid(Guid userUuid)
        {
            return await Context.QuizzesInfos.Where(x => x.UserOwnerId == userUuid).ToListAsync();
        }

        public async Task<IEnumerable<QuizInfo>> GetQuizInfoByDifferentUsers(Guid userUuid)
        {
            return await Context.QuizzesInfos.Where(x => x.UserOwnerId != userUuid).ToListAsync();
        }
    }
}
