using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using QZI.Core.Exceptions;
using QZI.Core.Services;
using QZI.Quiz.Domain.Quiz.Acl.Interface;
using QZI.Quiz.Domain.Quiz.Acl.Response;

namespace QZI.Quiz.Domain.Quiz.Acl
{
    public class CategoryServiceAcl : Service, ICategoryServiceAcl
    {
        private readonly HttpClient _httpClient;

        public CategoryServiceAcl(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://localhost:44343");
            _httpClient = httpClient;
        }

        public async Task<GetCategoryByIdResponse> GetCategoryById(int categoryId)
        {
            AddHeaders(categoryId);
            var response = await _httpClient.PostAsync("/api/category/get-by-id", null!);

            await ResponseContainsErrors(response);

            return await DeserializeObjectResponse<GetCategoryByIdResponse>(response);
        }

        private void AddHeaders(int categoryId)
        {
            _httpClient.DefaultRequestHeaders.Add("categoryId", categoryId.ToString());
        }

        private async Task ResponseContainsErrors(HttpResponseMessage response)
        {
            var responseResult = await ProcessResponse(response);
            var message = responseResult.Errors.Messages.FirstOrDefault();

            if (!response.IsSuccessStatusCode)
            {
                throw new NotFoundException(message);
            }

            response.EnsureSuccessStatusCode();
        }
    }
}
