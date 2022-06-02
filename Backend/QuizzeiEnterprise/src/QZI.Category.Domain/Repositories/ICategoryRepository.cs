using System.Collections.Generic;
using System.Threading.Tasks;
using QZI.Category.Domain.Repositories.Base;

namespace QZI.Category.Domain.Repositories
{
    public interface ICategoryRepository : IRepository<Entities.Category>
    {
        Task<Entities.Category> GetCategoryById(int categoryId);
        Task<IList<Entities.Category>> GetAllCategories();
    }
}
