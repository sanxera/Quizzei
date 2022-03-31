using System.Threading.Tasks;

namespace QZI.User.Domain.User.Repositories
{
    public interface IUserRepository
    {
        Task InsertNewUser(Entities.PersonalUser newPersonalUser);
        Task<Entities.PersonalUser> FindUserByEmail(string email);
    }
}
