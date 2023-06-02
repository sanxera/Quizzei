using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QZI.Quizzei.Application.Shared.Entities;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Infra.Data.Repository.Base;

namespace QZI.Quizzei.Infra.Data.Repository;

public class QuestionCategoryRepository : RepositoryBase<QuestionCategory>, IQuestionCategoryRepository
{
    public QuestionCategoryRepository(QuizzeiContext context) : base(context) { }

    public async Task<QuestionCategory?> GetQuestionCategoryById(int categoryId)
    {
        return await Context.QuestionsCategories.FirstOrDefaultAsync(x => x.Id == categoryId);
    }

    public async Task<IList<QuestionCategory>> GetQuestionsCategoriesInRange(int range)
    {
        return await Context.QuestionsCategories.Where(x => x.Active).Take(range).ToListAsync();
    }

    public async Task<IList<QuestionCategory>> GetAllQuestionsCategories()
    {
        return await Context.QuestionsCategories.Where(x => x.Active).ToListAsync();
    }
}