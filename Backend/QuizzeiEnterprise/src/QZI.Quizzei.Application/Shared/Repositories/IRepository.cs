using QZI.Quizzei.Application.Shared.Entities;

namespace QZI.Quizzei.Application.Shared.Repositories;

public interface IRepository<in T> where T : Entity
{
    void Update(T entity);
    Task AddAsync(T entity);
}