using System.Threading.Tasks;

namespace QZI.User.Domain.User.Repositories
{
    public interface IUserRepository
    {
        Task InsertNewUser(Entities.User newUser);
    }
}
