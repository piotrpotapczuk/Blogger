using Application.Dto;

namespace Application.Interfaces
{
    public interface IPostService
    {
        IEnumerable<PostDto> GetAllPosts();
        PostDto GetPostById(int id);
        PostDto AddNewPost(CreatePostDto newPost);

        void UpdatePost(UpdatePostDto updatePostDto);
        void DeletePost(int id);
        IEnumerable<PostDto> SearchPostsByTitleSearchPhrase(string searchPhrase);
    }
}
