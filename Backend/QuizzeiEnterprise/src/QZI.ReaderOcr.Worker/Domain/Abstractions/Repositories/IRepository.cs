using QZI.ReaderOcr.Worker.Domain.Abstractions.Entities;

namespace QZI.ReaderOcr.Worker.Domain.Abstractions.Repositories;

public interface IRepository<in T> where T : OcrEntity
{
    void Update(T entity);
    Task AddAsync(T entity);
}