using Module5Homework1.Services.Abstraction;

namespace Module5Homework1
{
    public class App
    {
        private readonly IUserService _userService;
        private readonly IResourceService _resourceService;
        private readonly IEmployeeService _employeeService;
        private readonly IAuthService _authService;

        public App(IUserService userService, IResourceService resourceService, IEmployeeService employeeService, IAuthService authService)
        {
            _userService = userService;
            _resourceService = resourceService;
            _employeeService = employeeService;
            _authService = authService;
        }

        public async Task Start()
        {
            var list = new List<Task>();

            list.Add(Task.Run(async () => await _userService.GetUsers()));
            list.Add(Task.Run(async () => await _userService.GetUsersWithDelay(3)));
            list.Add(Task.Run(async () => await _userService.GetUserById(2)));
            list.Add(Task.Run(async () => await _userService.GetUserById(23)));

            list.Add(Task.Run(async () => await _resourceService.GetResources()));
            list.Add(Task.Run(async () => await _resourceService.GetResourceById(2)));
            list.Add(Task.Run(async () => await _resourceService.GetResourceById(23)));

            list.Add(Task.Run(async () => await _employeeService.Create("morpheus", "leader")));
            list.Add(Task.Run(async () => await _employeeService.Update(2, "morpheus", "zion resident")));
            list.Add(Task.Run(async () => await _employeeService.Update(2, "morpheus", "zion resident", true)));
            list.Add(Task.Run(async () => await _employeeService.Delete(2)));

            list.Add(Task.Run(async () => await _authService.Login("eve.holt@reqres.in", "cityslicka")));
            list.Add(Task.Run(async () => await _authService.Login("peter@klaven", null!)));
            list.Add(Task.Run(async () => await _authService.Register("eve.holt@reqres.in", "pistol")));
            list.Add(Task.Run(async () => await _authService.Register("sydney@fife", null!)));

            await Task.WhenAll(list);
        }
    }
}
