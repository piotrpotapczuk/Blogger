using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
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
            this._postRepository = postRepository;
            this._mapper = mapper;
        }



        public IEnumerable<PostDto> GetAllPosts()
        {
            var posts = _postRepository.GetAll();
            return _mapper.Map<IEnumerable<PostDto>>(posts);
       
        }

        public PostDto GetPostById(int id)
        {
            var post = _postRepository.GetById(id);
            return _mapper.Map<PostDto>(post);  
        }

        public PostDto AddNewPost(CreatePostDto newPost)
        {
            if(string.IsNullOrEmpty(newPost.Title))
            {
                throw new Exception("Post can not have an empty Title");

            }

            Post post = _mapper.Map<Post>(newPost);
            _postRepository.Add(post);

            return _mapper.Map<PostDto>(post);
        }

        public void UpdatePost(UpdatePostDto updatePostDto)
        {
            var existingPost = _postRepository.GetById(updatePostDto.Id);

            var post = _mapper.Map(updatePostDto, existingPost);
            _postRepository.Update(post);

        }

        public void DeletePost(int id)
        {
            Post post = _postRepository.GetById(id);
            _postRepository.Delete(post);
        }

        public IEnumerable<PostDto> SearchPostsByTitleSearchPhrase(string searchPhrase)
        {
            var posts = _postRepository.GetAll()
                                       .Where(p => p.Title.ToLower().Contains(searchPhrase.ToLower()))
                                       .ToList();

            var postDtos = _mapper.Map<IEnumerable<PostDto>>(posts);

            return postDtos;
        }
    }
}
