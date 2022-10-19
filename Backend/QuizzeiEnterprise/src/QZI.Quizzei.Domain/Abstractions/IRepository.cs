using System.Threading.Tasks;

namespace QZI.Quizzei.Domain.Abstractions
{
    public interface IRepository<in T> where T : Entity
    {
        void Update(T entity);
        Task AddAsync(T entity);
    }
}
