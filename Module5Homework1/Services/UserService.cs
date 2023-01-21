using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Module5Homework1.Config;
using Module5Homework1.Dtos;
using Module5Homework1.Dtos.Responses;
using Module5Homework1.Services.Abstraction;

namespace Module5Homework1.Services
{
    public class UserService : IUserService
    {
        private readonly IInternalHttpClientService _httpClientService;
        private readonly ILogger<UserService> _logger;
        private readonly ApiOptions _options;
        private readonly string _userApi = "api/users/";

        public UserService(
            IInternalHttpClientService httpClientService,
            IOptions<ApiOptions> options,
            ILogger<UserService> logger)
        {
            _httpClientService = httpClientService;
            _options = options.Value;
            _logger = logger;
        }

        public async Task<ItemResponse<UserDto>> GetUserById(int id)
        {
            var response = await _httpClientService.SendAsync<ItemResponse<UserDto>, object>($"{_options.Host}{_userApi}{id}", HttpMethod.Get);

            if (response != null)
            {
                var user = response.Item;
                _logger.LogInformation($"Single user {user.FirstName} {user.LastName} has found!\n");
            }
            else
            {
                _logger.LogWarning($"Single user with id {id} has not found!\n");
            }

            return response!;
        }

        public async Task<ItemCollectionResponse<UserDto>> GetUsers()
        {
            var response = await _httpClientService.SendAsync<ItemCollectionResponse<UserDto>, object>($"{_options.Host}{_userApi}", HttpMethod.Get);
            var users = response.Items;

            if (response != null)
            {
                _logger.LogInformation($"List of {users.Count()} users has found.\n");
            }

            return response!;
        }

        public async Task<ItemCollectionResponse<UserDto>> GetUsersWithDelay(int delay)
        {
            var parameters = $"delay={delay}";
            var response = await _httpClientService.SendAsync<ItemCollectionResponse<UserDto>, object>($"{_options.Host}{_userApi}?{parameters}", HttpMethod.Get);
            var users = response.Items;

            if (response != null)
            {
                _logger.LogInformation($"List of {users.Count()} users has found after {delay} seconds delay.\n");
            }

            return response!;
        }
    }
}
