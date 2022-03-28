using System;
using System.Net.Http;
using System.Threading.Tasks;
using QZI.Core.Abstract;
using QZI.Core.Communication;
using QZI.User.Domain.User.Handlers.Requests;
using QZI.User.Domain.User.Handlers.Responses;
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

        public async Task<LoginUserResponse> Login(LoginUserRequest request)
        {
            var loginContent = GetContent(request);

            var response = await _httpClient.PostAsync("/api/identity/login", loginContent);

            if (!TreatErrorsResponse(response))
            {
                return new LoginUserResponse
                {
                    Logged = false,
                    ResponseResult = await DeserializeObjectResponse<ResponseResult>(response)
                };
            }

            return await DeserializeObjectResponse<LoginUserResponse>(response);
        }

        public async Task<CreateUserResponse> RegisterIdentityUser(CreateIdentityUserRequest request)
        {
            var registerContent = GetContent(request);

            var response = await _httpClient.PostAsync("/api/identity/register", registerContent);

            if (!TreatErrorsResponse(response))
            {
                return new CreateUserResponse
                {
                    Created = false,
                    ResponseResult = await DeserializeObjectResponse<ResponseResult>(response)
                };
            }

            return await DeserializeObjectResponse<CreateUserResponse>(response);
        }
    }
}
