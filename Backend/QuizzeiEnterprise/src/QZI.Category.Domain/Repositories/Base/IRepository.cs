using System.Threading.Tasks;
using QZI.Category.Domain.Entities.Base;

namespace QZI.Category.Domain.Repositories.Base
{
    public interface IRepository<in T> where T : Entity
    {
        void Update(T entity);
        Task AddAsync(T entity);
    }
}
