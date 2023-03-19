using System.Threading.Tasks;

namespace QZI.Quizzei.Domain.Abstractions.UnitOfWork;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}