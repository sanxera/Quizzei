﻿using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using QZI.Core.Communication;

namespace QZI.Core.Services
{
    public abstract class Service
    {
        protected static StringContent GetContent(object data)
        {
            return new StringContent(JsonSerializer.Serialize(data),
                Encoding.UTF8,
                "application/json");
        }

        protected async Task<T> DeserializeObjectResponse<T>(HttpResponseMessage responseMessage)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<T>(await responseMessage.Content.ReadAsStringAsync(), options);
        }

        protected async Task<ResponseResult> ProcessResponse(HttpResponseMessage response)
        {
            return await DeserializeObjectResponse<ResponseResult>(response);
        }
    }
}
