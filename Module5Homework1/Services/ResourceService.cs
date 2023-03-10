using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Module5Homework1.Config;
using Module5Homework1.Dtos.Responses;
using Module5Homework1.Dtos;
using Module5Homework1.Services.Abstraction;

namespace Module5Homework1.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IInternalHttpClientService _httpClientService;
        private readonly ILogger<ResourceService> _logger;
        private readonly ApiOptions _options;
        private readonly string _userApi = "api/unknown/";

        public ResourceService(
            IInternalHttpClientService httpClientService,
            IOptions<ApiOptions> options,
            ILogger<ResourceService> logger)
        {
            _httpClientService = httpClientService;
            _options = options.Value;
            _logger = logger;
        }

        public async Task<ItemResponse<ResourceDto>> GetResourceById(int id)
        {
            var response = await _httpClientService.SendAsync<ItemResponse<ResourceDto>, object>($"{_options.Host}{_userApi}{id}", HttpMethod.Get);

            if (response != null)
            {
                var user = response.Item;
                _logger.LogInformation($"Single resource {user.Name} has found\n");
            }
            else
            {
                _logger.LogWarning($"Single resource with id {id} has not found!\n");
            }

            return response!;
        }

        public async Task<ItemCollectionResponse<ResourceDto>> GetResources()
        {
            var response = await _httpClientService.SendAsync<ItemCollectionResponse<ResourceDto>, object>($"{_options.Host}{_userApi}", HttpMethod.Get);
            var users = response.Items;

            if (response != null)
            {
                _logger.LogInformation($"List of {users.Count()} resources has found.\n");
            }

            return response!;
        }
    }
}
