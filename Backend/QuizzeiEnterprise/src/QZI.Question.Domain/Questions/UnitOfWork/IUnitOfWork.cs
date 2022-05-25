using System.Threading.Tasks;

namespace QZI.Question.Domain.Questions.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
