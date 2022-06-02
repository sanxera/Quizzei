using System.Threading.Tasks;
using QZI.Question.Domain.Questions.UnitOfWork;

namespace QZI.Question.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuestionContext _context;

        public UnitOfWork(QuestionContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
