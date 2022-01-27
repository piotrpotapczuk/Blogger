using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers.V2
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiVersion(version:"2.0")]
    // gdy wersje przekazujemy w URI
    //[Route("api/{v:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostsController(IPostService postService, IMapper mapper)
        {
            this._postService = postService;
            this._mapper = mapper;
        }

        [SwaggerOperation(Summary = "Return all posts")]
        [HttpGet]
        public IActionResult Get()
        {
            var posts = _postService.GetAllPosts();

            return Ok(new
            {
                Post = posts,
                PostsCount = posts.Count()
            });
        }

        [SwaggerOperation(Summary = "Return post by unique identifier")]
        //[HttpGet(Name = "id")]
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            PostDto post = _postService.GetPostById(id);
            if(post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [SwaggerOperation(Summary = "Create a new post")]
        [HttpPost]
        public IActionResult Create(CreatePostDto createPostDto)
        {
            PostDto postDto = _postService.AddNewPost(createPostDto);

            return Created($"api/posts/{postDto.Id}", postDto);
        }

        [SwaggerOperation(Summary = "Update an existing post")]
        [HttpPut]
        public IActionResult Update(UpdatePostDto updatePostDto)
        {
            _postService.UpdatePost(updatePostDto);

            return NoContent();
        }

        [SwaggerOperation(Summary = "Delete an existing post by unique identifier")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _postService.DeletePost(id);
            return NoContent(); 
        }
    }
}
