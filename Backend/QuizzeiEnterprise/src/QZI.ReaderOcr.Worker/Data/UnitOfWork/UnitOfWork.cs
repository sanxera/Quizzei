using QZI.ReaderOcr.Worker.Domain.Abstractions.UnitOfWork;

namespace QZI.ReaderOcr.Worker.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuizzeiOcrContext _context;

        public UnitOfWork(QuizzeiOcrContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
