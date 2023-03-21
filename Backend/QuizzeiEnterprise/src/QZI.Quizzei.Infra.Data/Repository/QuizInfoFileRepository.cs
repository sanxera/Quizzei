using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QZI.Quizzei.Application.Shared.Entities;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Infra.Data.Repository.Base;

namespace QZI.Quizzei.Infra.Data.Repository;

public class QuizInfoFileRepository : RepositoryBase<QuizInformationFile>, IQuizInfoFileRepository
{
    public QuizInfoFileRepository(QuizzeiContext context) : base(context) { }

    public async Task<QuizInformationFile> GetQuizInfoFileById(Guid id)
    {
        return await Context.QuizInformationFiles.FirstOrDefaultAsync(x => x.QuizInfoFileUuid == id);
    }

    public async Task<IList<QuizInformationFile>> GetQuizInfoFileInRange(int range)
    {
        return await Context.QuizInformationFiles.Take(range).ToListAsync();
    }
}