using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QZI.Quizzei.Domain.Domains.Category.Entities;
using QZI.Quizzei.Domain.Domains.Category.Repositories;
using QZI.Quizzei.Infra.Data.Repository.Base;

namespace QZI.Quizzei.Infra.Data.Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(QuizzeiContext context) : base(context) { }

        public async Task<Category> GetCategoryById(int categoryId)
        {
            return await Context.Categories.FirstOrDefaultAsync(x => x.Id == categoryId);
        }

        public async Task<IList<Category>> GetAllCategories()
        {
            return await Context.Categories.Where(x => x.Active).ToListAsync();
        }
    }
}
