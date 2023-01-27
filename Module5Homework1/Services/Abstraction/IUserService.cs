using Module5Homework1.Dtos;
using Module5Homework1.Dtos.Responses;

namespace Module5Homework1.Services.Abstraction
{
    public interface IUserService
    {
        Task<ItemResponse<UserDto>> GetUserById(int id);
        Task<ItemCollectionResponse<UserDto>> GetUsers();
        Task<ItemCollectionResponse<UserDto>> GetUsersWithDelay(int delay);
    }
}
