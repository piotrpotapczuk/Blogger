using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;


namespace WebAPI.Controllers.V2
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {

        //private readonly IPostService _postService;
        //public PostsController(IPostService postService)
        //{
        //    _postService = postService;
        //}


        //[SwaggerOperation(Summary = "Retrives all posts")]
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var posts = _postService.GetAllPosts();

        //    return Ok(new
        //    {
        //        Posts = posts,
        //        Cout = posts.Count()
        //    });
        //}

        //[SwaggerOperation(Summary = "Retrives post by id")]
        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    var post = _postService.GetPostById(id);
        //    if (post == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(post);
        //}

        //[SwaggerOperation(Summary = "Create a new post")]
        //[HttpPost]
        //public IActionResult Create(CreatePostDto newPost)
        //{
        //    var post = _postService.AddNewPost(newPost);

        //    return Created(uri: $"api/posts/{post.Id}", post);
        //}

        //[SwaggerOperation(Summary = "Update a post")]
        //[HttpPut]
        //public IActionResult Update(UpdatePostDto updatePost)
        //{
        //    _postService.UpdatePost(updatePost);

        //    return NoContent();
        //}

        //[SwaggerOperation(Summary = "Delete a  post")]
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    _postService.DeletePost(id);

        //    return NoContent();
        //}

    }
}
