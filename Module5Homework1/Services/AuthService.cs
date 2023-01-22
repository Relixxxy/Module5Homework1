using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Module5Homework1.Config;
using Module5Homework1.Dtos;
using Module5Homework1.Dtos.Requests;
using Module5Homework1.Dtos.Responses;
using Module5Homework1.Services.Abstraction;

namespace Module5Homework1.Services
{
    public class AuthService : IAuthService
    {
        private readonly IInternalHttpClientService _httpClientService;
        private readonly ILogger<AuthService> _logger;
        private readonly ApiOptions _options;
        private readonly string _url = "api/";

        public AuthService(IInternalHttpClientService httpClientService, ILogger<AuthService> logger, IOptions<ApiOptions> options)
        {
            _httpClientService = httpClientService;
            _logger = logger;
            _options = options.Value;
        }

        public async Task<LoginResponse> Login(string email, string password)
        {
            string url = $"{_options.Host}{_url}login";
            var authData = new AuthRequest { Email = email, Password = password };
            var response = await _httpClientService.SendAsync<LoginResponse, object>(url, HttpMethod.Post, authData);

            if (response != null)
            {
                _logger.LogInformation($"Successfully login with token {response.Token}\n");
            }

            return response!;
        }

        public async Task<RegisterResponse> Register(string email, string password)
        {
            string url = $"{_options.Host}{_url}register";

            var authData = new AuthRequest { Email = email, Password = password };
            var response = await _httpClientService.SendAsync<RegisterResponse, object>(url, HttpMethod.Post, authData);

            if (response != null)
            {
                _logger.LogInformation($"Successfully register with token {response.Token} and id {response.Id}\n");
            }

            return response!;
        }
    }
}
