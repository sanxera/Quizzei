using System;
using System.Threading.Tasks;
using QZI.Quizzei.Domain.Domains.User.Entities;
using QZI.Quizzei.Domain.Domains.User.Request;

namespace QZI.Quizzei.Domain.Domains.User.Service.Abstractions
{
    public interface IUserService
    {
        Task<Guid> CreateUser(CreateUserRequest request);
        Task<Guid> CreateRole(CreateRoleRequest request);
        Task<BaseUser> GetUserByEmail(string email);
    }
}
