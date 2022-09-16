using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
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
        public IActionResult Get()
        {
            var posts = _postService.GetAllPosts();

            return Ok(posts);
        }

        [SwaggerOperation(Summary = "Retrives post by id")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var post = _postService.GetPostById(id);
            if(post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [SwaggerOperation(Summary = "Create a new post")]
        [HttpPost]
        public IActionResult Create(CreatePostDto newPost)
        {
           var post = _postService.AddNewPost(newPost);

            return Created(uri: $"api/posts/{post.Id}", post);
        }

    }
}
