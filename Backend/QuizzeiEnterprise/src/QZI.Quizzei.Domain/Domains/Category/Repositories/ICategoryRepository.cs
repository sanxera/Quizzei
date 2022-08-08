using System.Collections.Generic;
using System.Threading.Tasks;
using QZI.Quizzei.Domain.Domains.Category.Repositories.Base;

namespace QZI.Quizzei.Domain.Domains.Category.Repositories
{
    public interface ICategoryRepository : IRepository<Entities.Category>
    {
        Task<Entities.Category> GetCategoryById(int categoryId);
        Task<IList<Entities.Category>> GetAllCategories();
    }
}
