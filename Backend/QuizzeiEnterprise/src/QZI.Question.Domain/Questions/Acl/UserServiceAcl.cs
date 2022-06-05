using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using QZI.Core.Exceptions;
using QZI.Core.Services;
using QZI.Question.Domain.Questions.Acl.Interface;
using QZI.Question.Domain.Questions.Acl.Response;

namespace QZI.Question.Domain.Questions.Acl
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
                throw new NotFoundException(message);
            }

            response.EnsureSuccessStatusCode();
        }
    }
}
