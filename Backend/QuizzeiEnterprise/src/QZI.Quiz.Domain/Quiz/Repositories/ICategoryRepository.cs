using System.Collections.Generic;
using System.Threading.Tasks;
using QZI.Quiz.Domain.Quiz.Entities;

namespace QZI.Quiz.Domain.Quiz.Repositories
{
    public interface ICategoryRepository
    {
        Task AddNewCategory(QuizCategory quizCategory);
        Task<QuizCategory> GetCategoryById(int categoryId);
        IList<QuizCategory> GetAllCategories();
    }
}
