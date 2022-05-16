using System.Threading.Tasks;
using QZI.User.Domain.User.Handlers.Requests;
using QZI.User.Domain.User.Handlers.Responses;
using QZI.User.Domain.User.Services.Requests;

namespace QZI.User.Domain.User.Services.Interfaces
{
    public interface IAuthUserService
    {
        Task<LoginUserResponse> Login(LoginUserRequest request);
        Task<CreateUserResponse> RegisterIdentityUser(CreateIdentityUserRequest request);
    }
}
