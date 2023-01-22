using Module5Homework1.Dtos;
using Module5Homework1.Dtos.Responses;

namespace Module5Homework1.Services.Abstraction
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(string email, string password);
        Task<RegisterResponse> Register(string email, string password);
    }
}
