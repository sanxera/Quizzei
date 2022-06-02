using System.Threading.Tasks;
using QZI.Question.Domain.Questions.Entities.Base;

namespace QZI.Question.Domain.Questions.Repositories.Base
{
    public interface IRepository<in T> where T : Entity
    {
        void Update(T entity);
        Task AddAsync(T entity);
    }
}
