using System.Threading.Tasks;
using QZI.Quiz.Domain.Quiz.Entities.Base;
using QZI.Quiz.Domain.Quiz.Repositories.Base;

namespace QZI.Quiz.Infra.Data.Data.Repository.Base
{
    public class RepositoryBase<T> : IRepository<T> where T : Entity
    {
        protected readonly QuizContext Context;

        public RepositoryBase(QuizContext context)
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
