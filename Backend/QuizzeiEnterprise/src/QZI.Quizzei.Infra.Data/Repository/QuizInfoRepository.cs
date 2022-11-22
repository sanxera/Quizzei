using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QZI.Quizzei.Domain.Domains.Quiz.Entities;
using QZI.Quizzei.Domain.Domains.Quiz.Repositories;
using QZI.Quizzei.Infra.Data.Repository.Base;

namespace QZI.Quizzei.Infra.Data.Repository
{
    public class QuizInfoRepository : RepositoryBase<QuizInformation>, IQuizInfoRepository
    {
        public QuizInfoRepository(QuizzeiContext context) : base(context) { }

        public async Task<QuizInformation> GetQuizInfoById(Guid id)
        {
            return await Context.QuizzesInfos
                .Include(x => x.Files)
                .FirstOrDefaultAsync(x => x.QuizInfoUuid == id);
        }

        public async Task<IEnumerable<QuizInformation>> GetQuizInfoByUserUuid(Guid userUuid)
        {
            return await Context.QuizzesInfos.Where(x => x.UserOwnerId == userUuid).ToListAsync();
        }

        public async Task<IEnumerable<QuizInformation>> GetQuizInfoByDifferentUsers(Guid userUuid)
        {
            return await Context.QuizzesInfos.Where(x => x.UserOwnerId != userUuid).ToListAsync();
        }

        public async Task<IEnumerable<QuizInformation>> GetQuizzesByTitle(string name)
        {
            return await Context.QuizzesInfos.Where(x => EF.Functions.Like(x.Title, $"%{name}%")).ToListAsync();
        }

        public async Task<IEnumerable<QuizInformation>> GetQuizzesByCategory(int categoryId)
        {
            return await Context.QuizzesInfos.Where(x => x.CategoryId == categoryId).ToListAsync();
        }
    }
}
