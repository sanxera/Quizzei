
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QZI.Quiz.Domain.Quiz.Entities;
using QZI.Quiz.Domain.Quiz.Repositories;

namespace QZI.Quiz.Infra.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly QuizContext context;

        public CategoryRepository(QuizContext context)
        {
            this.context = context;
        }

        public async Task AddNewCategory(QuizCategory quizCategory)
        {
            context.QuizCategories.Add(quizCategory);
            await context.SaveChangesAsync();
        }

        public async Task<QuizCategory> GetCategoryById(int categoryId)
        {
            return await context.QuizCategories.FirstOrDefaultAsync(x => x.QuizCategoryId == categoryId);
        }

        public IList<QuizCategory> GetAllCategories()
        {
            return context.QuizCategories.Where(x => x.Active).ToList();
        }
    }
}
