namespace QZI.ReaderOcr.Worker.Domain.Abstractions.UnitOfWork;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}