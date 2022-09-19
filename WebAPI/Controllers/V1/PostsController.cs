using Application.Dto;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }


        [SwaggerOperation(Summary = "Retrives all posts")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts = await _postService.GetAllPostsAsync();

            return Ok(posts);
        }

        [SwaggerOperation(Summary = "Retrives posts by title")]
        [HttpGet("Search/{title}")]
        public async Task<IActionResult> Search(string title)
        {
           

            var posts = await _postService.GetAllPostsAsync(title);
           

            return Ok(posts);
        }

        [SwaggerOperation(Summary = "Retrives post by id")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [SwaggerOperation(Summary = "Create a new post")]
        [HttpPost]
        public async Task<IActionResult> Create(CreatePostDto newPost)
        {
            var post = await _postService.AddNewPostAsync(newPost);

            return Created(uri: $"api/posts/{post.Id}", post);
        }

        [SwaggerOperation(Summary = "Update a post")]
        [HttpPut]
        public async Task<IActionResult> Update(UpdatePostDto updatePost)
        {
            await _postService.UpdatePostAsync(updatePost);

            return NoContent();
        }

        [SwaggerOperation(Summary = "Delete a  post")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _postService.DeletePostAsync(id);

            return NoContent();
        }

    }
}
