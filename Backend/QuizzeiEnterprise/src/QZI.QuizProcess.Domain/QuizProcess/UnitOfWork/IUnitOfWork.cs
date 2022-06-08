using System.Threading.Tasks;

namespace QZI.Quiz.Domain.Quiz.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
