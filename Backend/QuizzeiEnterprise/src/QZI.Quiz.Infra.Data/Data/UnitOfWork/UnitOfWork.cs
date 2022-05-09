using System.Threading.Tasks;
using QZI.Quiz.Domain.Quiz.UnitOfWork;

namespace QZI.Quiz.Infra.Data.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuizContext _context;

        public UnitOfWork(QuizContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
