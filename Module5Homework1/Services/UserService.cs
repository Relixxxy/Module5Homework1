using Microsoft.Extensions.Logging;
using Module5Homework1.Services.Abstraction;

namespace Module5Homework1.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;

        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }

        public async Task HelloWorldAsync()
        {
            _logger.LogInformation("Hello Start");
            await Task.Run(() => Console.WriteLine("Hello, world!"));
            _logger.LogInformation("Hello End");
        }
    }
}
