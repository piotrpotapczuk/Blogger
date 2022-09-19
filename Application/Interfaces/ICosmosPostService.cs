
using Application.Dto.Cosmos;

namespace Application.Interfaces
{
    public interface ICosmosPostService
    {
        Task<IEnumerable<CosmosPostDto>> GetAllPostsAsync();
        Task<IEnumerable<CosmosPostDto>> GetAllPostsAsync(string title);

        Task<CosmosPostDto> GetPostByIdAsync(string id);

        Task<CosmosPostDto> AddNewPostAsync(CreateCosmosPostDto newPost);

        Task UpdatePostAsync(UpdateCosmosPostDto updatePost);

        Task DeletePostAsync(string id);
    }
}
