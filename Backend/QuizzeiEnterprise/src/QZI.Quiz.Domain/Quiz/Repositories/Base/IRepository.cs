using System.Threading.Tasks;
using QZI.Quiz.Domain.Quiz.Entities.Base;

namespace QZI.Quiz.Domain.Quiz.Repositories.Base
{
    public interface IRepository<in T> where T : Entity
    {
        void Update(T entity);
        Task AddAsync(T entity);
    }
}
