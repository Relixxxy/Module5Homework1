using Module5Homework1.Dtos.Responses;
using Module5Homework1.Dtos;

namespace Module5Homework1.Services.Abstraction
{
    public interface IResourceService
    {
        Task<ItemResponse<ResourceDto>> GetResourceById(int id);
        Task<ItemCollectionResponse<ResourceDto>> GetResources();
    }
}
