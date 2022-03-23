using System.Threading.Tasks;
using QZI.User.Domain.User.Repositories;

namespace QZI.User.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly QuizzeiContext _context;

        public UserRepository(QuizzeiContext context)
        {
            _context = context;
        }

        public async Task InsertNewUser(Domain.User.Entities.User newUser)
        {
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
        }
    }
}
