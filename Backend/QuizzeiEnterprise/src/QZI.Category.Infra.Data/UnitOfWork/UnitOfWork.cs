using System.Threading.Tasks;
using QZI.Category.Domain.UnitOfWork;

namespace QZI.Category.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CategoryContext _context;

        public UnitOfWork(CategoryContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
