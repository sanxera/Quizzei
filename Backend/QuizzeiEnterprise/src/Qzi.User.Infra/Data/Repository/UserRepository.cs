using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QZI.User.Domain.User.Entities;
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

        public async Task InsertNewUser(PersonalUser newPersonalUser)
        {
            await _context.Users.AddAsync(newPersonalUser);
            await _context.SaveChangesAsync();
        }

        public async Task<PersonalUser> FindUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
