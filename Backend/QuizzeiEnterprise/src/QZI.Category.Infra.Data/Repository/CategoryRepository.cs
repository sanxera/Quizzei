using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QZI.Category.Domain.Repositories;
using QZI.Category.Infra.Data.Repository.Base;

namespace QZI.Category.Infra.Data.Repository
{
    public class CategoryRepository : RepositoryBase<Domain.Entities.Category>, ICategoryRepository
    {
        public CategoryRepository(CategoryContext context) : base(context) { }

        public async Task<Domain.Entities.Category> GetCategoryById(int categoryId)
        {
            return await Context.QuizCategories.FirstOrDefaultAsync(x => x.Id == categoryId);
        }

        public async Task<IList<Domain.Entities.Category>> GetAllCategories()
        {
            return await Context.QuizCategories.Where(x => x.Active).ToListAsync();
        }
    }
}
