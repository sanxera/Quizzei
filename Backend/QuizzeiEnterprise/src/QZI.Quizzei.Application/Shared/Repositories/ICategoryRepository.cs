using QZI.Quizzei.Application.Shared.Entities;

namespace QZI.Quizzei.Application.Shared.Repositories;

public interface ICategoryRepository : IRepository<Category>
{
    Task<Category> GetCategoryById(int categoryId);
    Task<IList<Category>> GetCategoriesInRange(int range);
    Task<IList<Category>> GetAllCategories();
}