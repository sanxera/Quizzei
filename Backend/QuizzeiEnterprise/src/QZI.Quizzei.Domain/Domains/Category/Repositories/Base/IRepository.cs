using System.Threading.Tasks;
using QZI.Quizzei.Domain.Abstractions;

namespace QZI.Quizzei.Domain.Domains.Category.Repositories.Base
{
    public interface IRepository<in T> where T : Entity
    {
        void Update(T entity);
        Task AddAsync(T entity);
    }
}
