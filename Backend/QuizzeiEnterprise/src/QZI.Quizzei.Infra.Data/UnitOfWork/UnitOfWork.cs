using System.Threading.Tasks;
using QZI.Quizzei.Application.Shared.UnitOfWork;

namespace QZI.Quizzei.Infra.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly QuizzeiContext _context;

    public UnitOfWork(QuizzeiContext context)
    {
        _context = context;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}