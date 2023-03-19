#nullable enable
using System;
using System.Threading.Tasks;
using QZI.Quizzei.Domain.Domains.User.Service.Request;
using QZI.Quizzei.Domain.Domains.User.Service.Response;

namespace QZI.Quizzei.Domain.Domains.User.Service.Abstractions;

public interface IUserService
{
    Task<Guid> CreateUser(CreateUserRequest request);
    Task<Guid> CreateRole(CreateRoleRequest request);
    Task<UserBaseResponse> GetUserByEmail(string email);
    Task<UserBaseResponse> GetUserById(Guid userUuid);
    Task<GetUserDetailsResponse?> GetUserDetails(GetUserDetailsRequest request);
    Task<GetUserDetailsResponse?> GetUserDetails(GetLoggedUserDetailsRequest request);
}