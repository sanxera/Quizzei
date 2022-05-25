using System.Threading.Tasks;
using QZI.Question.Domain.Questions.Entities.Base;
using QZI.Question.Domain.Questions.Repositories.Base;

namespace QZI.Question.Infra.Data.Repository.Base
{
    public class RepositoryBase<T> : IRepository<T> where T : Entity
    {
        protected readonly QuestionContext Context;

        public RepositoryBase(QuestionContext context)
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
