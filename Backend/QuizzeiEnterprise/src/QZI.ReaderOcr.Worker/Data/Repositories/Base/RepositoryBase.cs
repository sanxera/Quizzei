using QZI.ReaderOcr.Worker.Domain.Abstractions.Entities;
using QZI.ReaderOcr.Worker.Domain.Abstractions.Repositories;

namespace QZI.ReaderOcr.Worker.Data.Repositories.Base
{
    public class RepositoryBase<T> : IRepository<T> where T : OcrEntity
    {
        protected readonly QuizzeiOcrContext Context;

        public RepositoryBase(QuizzeiOcrContext context)
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
