using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QZI.Quiz.Domain.Quiz.Entities;
using QZI.Quiz.Domain.Quiz.Repositories;
using QZI.Quiz.Infra.Data.Data.Repository.Base;

namespace QZI.Quiz.Infra.Data.Data.Repository
{
    public class CategoryRepository : RepositoryBase<QuizCategory>, ICategoryRepository
    {
        public CategoryRepository(QuizContext context) : base(context) { }

        public async Task<QuizCategory> GetCategoryById(int categoryId)
        {
            return await Context.QuizCategories.FirstOrDefaultAsync(x => x.QuizCategoryId == categoryId);
        }

        public IList<QuizCategory> GetAllCategories()
        {
            return Context.QuizCategories.Where(x => x.Active).ToList();
        }
    }
}
