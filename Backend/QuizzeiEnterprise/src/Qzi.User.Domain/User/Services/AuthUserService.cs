using System;
using System.Net.Http;
using System.Threading.Tasks;
using QZI.User.Domain.User.Handlers.Requests;
using QZI.User.Domain.User.Handlers.Responses;
using QZI.User.Domain.User.Services.Abstract;
using QZI.User.Domain.User.Services.Interfaces;

namespace QZI.User.Domain.User.Services
{
    public class AuthUserService : Service, IAuthUserService
    {
        private readonly HttpClient _httpClient;

        public AuthUserService(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://localhost:44348");
            _httpClient = httpClient;
        }

        public async Task<UserLoginResponse> Login(UserLoginRequest request)
        {
            var loginContent = GetContent(request);

            var response = await _httpClient.PostAsync("/api/identity/login", loginContent);

            return new UserLoginResponse {Token = await response.Content.ReadAsStringAsync() };
        }

        public async Task<CreateUserResponse> RegisterIdentityUser(CreateUserRequest request)
        {
            var registerContent = GetContent(request);

            await _httpClient.PostAsync("/api/identity/register", registerContent);

            return new CreateUserResponse {Created = true};
        }
    }
}
