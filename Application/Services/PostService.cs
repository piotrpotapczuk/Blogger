using Application.Dto;
using Application.Interfaces;
using AutoMapper;
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
        private readonly IMapper _mapper;

       public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public PostDto GetPostById(int id)
        {
            var post = _postRepository.GetById(id);

            /* manual
            return new PostDto
            {
               Id = post.Id,
               Title = post.Title,
               Content = post.Content
            };
            */

            return _mapper.Map<PostDto>(post);
        }

        public IEnumerable<PostDto> GetAllPosts()
        {
            var posts = _postRepository.GetAll();
            /* manual 
            return posts.Select(post => new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content
            });

            */

            return _mapper.Map<IEnumerable<PostDto>>(posts);
        }

    }
}
