using Module5Homework1.Services;
using Module5Homework1.Services.Abstraction;

namespace Module5Homework1
{
    public class App
    {
        private readonly IUserService _userService;

        public App(IUserService userService)
        {
            _userService = userService;
        }

        public async Task Start()
        {
            await _userService.HelloWorldAsync();
        }
    }
}
