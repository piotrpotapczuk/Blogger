using Application.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPostService
    {
        IQueryable<PostDto> GetAllPostsAsync();
        Task<IEnumerable<PostDto>> GetAllPostsAsync(int pageNumber, int pageSize, string sortField, bool acending, string filterBy);
        Task<int> GetAllPostCountAsync(string filterBy);
        Task<IEnumerable<PostDto>> GetAllPostsAsync(string title);

        Task<PostDto> GetPostByIdAsync(int id);

        Task<PostDto> AddNewPostAsync(CreatePostDto newPost);

        Task UpdatePostAsync(UpdatePostDto updatePost);

        Task DeletePostAsync(int id);



    }
}
