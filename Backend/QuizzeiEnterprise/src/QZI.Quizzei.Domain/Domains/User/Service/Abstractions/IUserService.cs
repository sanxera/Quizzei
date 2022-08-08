using System.Threading.Tasks;
using QZI.Quizzei.Domain.Domains.User.Entities;

namespace QZI.Quizzei.Domain.Domains.User.Service.Abstractions
{
    public interface IUserService
    {
        Task<Entities.BaseUser> GetUserByEmail(string email);
    }
}
