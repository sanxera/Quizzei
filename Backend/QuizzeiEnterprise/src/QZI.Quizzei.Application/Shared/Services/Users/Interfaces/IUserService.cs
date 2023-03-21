using QZI.Quizzei.Application.Shared.Services.Users.Response;

namespace QZI.Quizzei.Application.Shared.Services.Users.Interfaces;

public interface IUserService
{
    Task<GetUserResponse> GetUserAsync(string email);
    Task<GetUserResponse> GetUserAsync(Guid userUuid);
}