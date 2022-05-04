using System.Collections.Generic;
using System.Threading.Tasks;
using QZI.Quiz.Domain.Quiz.Entities;
using QZI.Quiz.Domain.Quiz.Repositories.Base;

namespace QZI.Quiz.Domain.Quiz.Repositories
{
    public interface ICategoryRepository : IRepository<QuizCategory>
    {
        Task<QuizCategory> GetCategoryById(int categoryId);
        IList<QuizCategory> GetAllCategories();
    }
}
