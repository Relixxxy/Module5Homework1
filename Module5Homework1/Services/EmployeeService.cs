using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Module5Homework1.Config;
using Module5Homework1.Dtos;
using Module5Homework1.Services.Abstraction;

namespace Module5Homework1.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IInternalHttpClientService _httpClientService;
        private readonly ILogger<EmployeeService> _logger;
        private readonly ApiOptions _options;
        private readonly string _url = "api/users/";

        public EmployeeService(IInternalHttpClientService httpClientService, ILogger<EmployeeService> logger, IOptions<ApiOptions> options)
        {
            _httpClientService = httpClientService;
            _logger = logger;
            _options = options.Value;
        }

        public async Task<EmployeeDto> Create(string name, string job)
        {
            var employee = new EmployeeDto() { Name = name, Job = job };
            var response = await _httpClientService.SendAsync<EmployeeDto, object>($"{_options.Host}{_url}", HttpMethod.Post, employee);

            if (response != null)
            {
                _logger.LogInformation($"Employee {response.Name} has successfully created with id {response.Id}!\n");
            }

            return response!;
        }

        public async Task Delete(int id)
        {
            var response = await _httpClientService.SendAsync<EmployeeDto, object>($"{_options.Host}{_url}{id}", HttpMethod.Delete);
        }

        public async Task<EmployeeDto> Update(int id, string name, string job, bool patch = false)
        {
            var employee = new EmployeeDto() { Name = name, Job = job };
            var method = patch ? HttpMethod.Patch : HttpMethod.Put;

            var response = await _httpClientService.SendAsync<EmployeeDto, object>($"{_options.Host}{_url}{id}", method, employee);

            if (response != null)
            {
                _logger.LogInformation($"Employee {response.Name} has successfully updated! ({method})\n");
            }

            return response!;
        }
    }
}
