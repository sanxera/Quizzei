using System.Threading.Tasks;

namespace QZI.Category.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
