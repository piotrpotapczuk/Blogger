using Application.Dto;
using Application.Interfaces;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PostService : IPostService
    {

        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public PostDto GetPostById(int id)
        {
            var post = _postRepository.GetById(id);

            return new PostDto
            {
               Id = post.Id,
               Title = post.Title,
               Content = post.Content
            };
        }

        public IEnumerable<PostDto> GetAllPosts()
        {
            var posts = _postRepository.GetAll();
            return posts.Select(post => new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content
            });
        }

    }
}
