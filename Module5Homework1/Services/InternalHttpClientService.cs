using System.Text;
using Module5Homework1.Services.Abstraction;
using Newtonsoft.Json;

namespace Module5Homework1.Services
{
    public class InternalHttpClientService : IInternalHttpClientService
    {
        private const string MEDIATYPE = "application/json";
        private readonly IHttpClientFactory _clientFactory;

        public InternalHttpClientService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<TResponse> SendAsync<TResponse, TRequest>(string url, HttpMethod method, TRequest? content = null)
            where TRequest : class
        {
            var client = _clientFactory.CreateClient();

            var httpMessage = new HttpRequestMessage(method, url);

            if (content != null)
            {
                var json = JsonConvert.SerializeObject(content);
                httpMessage.Content =
                    new StringContent(json, Encoding.UTF8, MEDIATYPE);
            }

            var result = await client.SendAsync(httpMessage);

            if (result.IsSuccessStatusCode)
            {
                var resultContent = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<TResponse>(resultContent);
                return response!;
            }

            return default(TResponse) !;
        }
    }
}
