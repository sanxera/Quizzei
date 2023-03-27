using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QZI.Quizzei.Application.Shared.Entities;
using QZI.Quizzei.Application.Shared.Enums;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Infra.Data.Repository.Base;

namespace QZI.Quizzei.Infra.Data.Repository;

public class QuizInfoRepository : RepositoryBase<QuizInformation>, IQuizInfoRepository
{
    public QuizInfoRepository(QuizzeiContext context) : base(context) { }

    public async Task<QuizInformation> GetQuizInfoById(Guid id)
    {
        return await Context.QuizzesInfos
            .Include(x => x.Files)
            .Include(a => a.QuizAccess)
            .FirstOrDefaultAsync(x => x.QuizInfoUuid == id);
    }

    public async Task<IEnumerable<QuizInformation>> GetQuizInfoByUserUuid(Guid userUuid)
    {
        return await Context.QuizzesInfos
            .Include(x => x.QuizAccess)
            .Where(x => x.UserOwnerId == userUuid)
            .ToListAsync();
    }

    public async Task<IEnumerable<QuizInformation>> GetQuizInfoByDifferentUsers(Guid userUuid)
    {
        return await Context.QuizzesInfos.Where(x => x.UserOwnerId != userUuid && x.PermissionType == PermissionType.Pubic).ToListAsync();
    }

    public async Task<IEnumerable<QuizInformation>> GetQuizzesByTitle(string name)
    {
        return await Context.QuizzesInfos.Where(x => EF.Functions.Like(x.Title, $"%{name}%")).ToListAsync();
    }

    public async Task<IEnumerable<QuizInformation>> GetQuizzesByCategoryFromOtherUsers(int categoryId, Guid userUuid)
    {
        return await Context.QuizzesInfos.Where(x => x.CategoryId == categoryId && x.UserOwnerId != userUuid && x.PermissionType == PermissionType.Pubic).ToListAsync();
    }
}