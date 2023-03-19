using System.Threading.Tasks;
using QZI.Quizzei.Domain.Abstractions;

namespace QZI.Quizzei.Infra.Data.Repository.Base;

public class RepositoryBase<T> : IRepository<T> where T : Entity
{
    protected readonly QuizzeiContext Context;

    public RepositoryBase(QuizzeiContext context)
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