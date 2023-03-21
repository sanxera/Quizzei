namespace QZI.Quizzei.Application.Shared.UnitOfWork;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}