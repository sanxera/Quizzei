using System.Threading.Tasks;
using QZI.Category.Domain.Entities.Base;
using QZI.Category.Domain.Repositories.Base;

namespace QZI.Category.Infra.Data.Repository.Base
{
    public class RepositoryBase<T> : IRepository<T> where T : Entity
    {
        protected readonly CategoryContext Context;

        public RepositoryBase(CategoryContext context)
        {
            Context = context;
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }

        public async Task AddAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
        }
    }
}
