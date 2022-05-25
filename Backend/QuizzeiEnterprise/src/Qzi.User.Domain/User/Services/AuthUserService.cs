using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using QZI.Core.Services;
using QZI.User.Domain.User.Exceptions;
using QZI.User.Domain.User.Handlers.Requests;
using QZI.User.Domain.User.Handlers.Responses;
using QZI.User.Domain.User.Services.Interfaces;
using QZI.User.Domain.User.Services.Requests;

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

        public async Task<LoginUserResponse> Login(LoginUserRequest request)
        {
            var loginContent = GetContent(request);

            var response = await _httpClient.PostAsync("/api/identity/login", loginContent);
            await ResponseContainsErrors(response);

            return await DeserializeObjectResponse<LoginUserResponse>(response);
        }

        public async Task<CreateUserResponse> RegisterIdentityUser(CreateIdentityUserRequest request)
        {
            var registerContent = GetContent(request);

            var response = await _httpClient.PostAsync("/api/identity/register", registerContent);

            await ResponseContainsErrors(response);

            return await DeserializeObjectResponse<CreateUserResponse>(response);
        }

        private async Task ResponseContainsErrors(HttpResponseMessage response)
        {
            var responseResult = await ProcessResponse(response);
            var message = responseResult.Errors.FirstOrDefault()?.Title;

            if (!response.IsSuccessStatusCode)
            {
                throw new LoginFailedException(message);
            }

            response.EnsureSuccessStatusCode();
        }
    }
}
