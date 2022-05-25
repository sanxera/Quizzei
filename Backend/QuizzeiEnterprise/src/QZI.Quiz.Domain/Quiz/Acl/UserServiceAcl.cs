using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using QZI.Core.Services;
using QZI.Quiz.Domain.Quiz.Acl.Interface;
using QZI.Quiz.Domain.Quiz.Acl.Response;
using QZI.Quiz.Domain.Quiz.Exceptions;

namespace QZI.Quiz.Domain.Quiz.Acl
{
    public class UserServiceAcl : Service, IUserServiceAcl
    {
        private readonly HttpClient _httpClient;

        public UserServiceAcl(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://localhost:44343");
            _httpClient = httpClient;
        }

        public async Task<GetUserByEmailResponse> GetUserIdByEmail(string email)
        {
            AddHeaders(email);
            var response = await _httpClient.PostAsync("/api/users/get-by-email", null!);

            await ResponseContainsErrors(response);

            return await DeserializeObjectResponse<GetUserByEmailResponse>(response);
        }

        private void AddHeaders(string email)
        {
            _httpClient.DefaultRequestHeaders.Add("email", email);
        }

        private async Task ResponseContainsErrors(HttpResponseMessage response)
        {
            var responseResult = await ProcessResponse(response);
            var message = responseResult.Errors.FirstOrDefault()?.Title;

            if (!response.IsSuccessStatusCode)
            {
                throw new GetUserEmailException(message);
            }

            response.EnsureSuccessStatusCode();
        }
    }
}
