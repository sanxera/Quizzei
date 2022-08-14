using System;
using System.Threading.Tasks;
using QZI.Quizzei.Domain.Domains.User.Request;
using QZI.Quizzei.Domain.Domains.User.Response;

namespace QZI.Quizzei.Domain.Domains.User.Service.Abstractions
{
    public interface IUserService
    {
        Task<Guid> CreateUser(CreateUserRequest request);
        Task<Guid> CreateRole(CreateRoleRequest request);
        Task<UserBaseResponse> GetUserByEmail(string email);
    }
}
