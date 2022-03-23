using System.Threading.Tasks;
using QZI.User.Domain.User.Handlers.Requests;
using QZI.User.Domain.User.Handlers.Responses;

namespace QZI.User.Domain.User.Services.Interfaces
{
    public interface IAuthUserService
    {
        Task<UserLoginResponse> Login(UserLoginRequest request);
    }
}
