using QZI.Quizzei.Application.Shared.Entities;

namespace QZI.Quizzei.Application.Shared.Repositories;

public interface IQuestionCategoryRepository : IRepository<QuestionCategory>
{
    Task<QuestionCategory?> GetQuestionCategoryById(int categoryId);
    Task<IList<QuestionCategory>> GetQuestionsCategoriesInRange(int range);
    Task<IList<QuestionCategory>> GetAllQuestionsCategories();
}