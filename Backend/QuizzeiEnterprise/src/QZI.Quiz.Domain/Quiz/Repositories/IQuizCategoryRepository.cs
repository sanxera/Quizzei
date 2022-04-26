using System.Threading.Tasks;
using QZI.Quiz.Domain.Quiz.Entities;

namespace QZI.Quiz.Domain.Quiz.Repositories
{
    public interface IQuizCategoryRepository
    {
        Task AddNewCategory(QuizCategory quizCategory);
        Task<QuizCategory> GetCategoryById(int categoryId);
    }
}
