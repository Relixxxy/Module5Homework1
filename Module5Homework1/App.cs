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

            list.Add(_userService.GetUsers());
            list.Add(_userService.GetUsersWithDelay(3));
            list.Add(_userService.GetUserById(2));
            list.Add(_userService.GetUserById(23));

            list.Add(_resourceService.GetResources());
            list.Add(_resourceService.GetResourceById(2));
            list.Add(_resourceService.GetResourceById(23));

            list.Add(_employeeService.Create("morpheus", "leader"));
            list.Add(_employeeService.Update(2, "morpheus", "zion resident"));
            list.Add(_employeeService.Update(2, "morpheus", "zion resident", true));
            list.Add(_employeeService.Delete(2));

            list.Add(_authService.Login("eve.holt@reqres.in", "cityslicka"));
            list.Add(_authService.Login("peter@klaven"));
            list.Add(_authService.Register("eve.holt@reqres.in", "pistol"));
            list.Add(_authService.Register("sydney@fife"));

            await Task.WhenAll(list);

            // This line was added to wait for logger
            Console.WriteLine("All done");
        }
    }
}
