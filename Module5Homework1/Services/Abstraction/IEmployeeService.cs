using Module5Homework1.Dtos;

namespace Module5Homework1.Services.Abstraction
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> Create(string name, string job);
        Task<EmployeeDto> Update(int id, string name, string job, bool patch = false);
        Task Delete(int id);
    }
}
