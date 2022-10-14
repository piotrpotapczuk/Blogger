using Application.Dto;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebAPI.Filters;
using WebAPI.Helpers;
using WebAPI.Wrappers;

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

        [SwaggerOperation(Summary = "Retrives sort fields")]
        [HttpGet("[action]")]
        public async Task<IActionResult> Get()
        {


            return Ok(SortingHelper.GetSortFields().Select(x=>x.Key));
        }


        [SwaggerOperation(Summary = "Retrives all posts")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationFilter paginationFilter, [FromQuery] SortingFilter sortingFilter, [FromQuery] string filterBy = "")
        {
            var validPagiantionFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);
            var validSortingFilter = new SortingFilter(sortingFilter.SortField, sortingFilter.Ascending);

            var posts = await _postService.GetAllPostsAsync(validPagiantionFilter.PageNumber, validPagiantionFilter.PageSize,
                                                            validSortingFilter.SortField, validSortingFilter.Ascending, filterBy);
            var totalRecords = await _postService.GetAllPostCountAsync(filterBy);

            return Ok(PaginationHelper.CreatePagedResponse(posts, validPagiantionFilter, totalRecords));
        }

        [SwaggerOperation(Summary = "Retrives posts by title")]
        [HttpGet("Search/{title}")]
        public async Task<IActionResult> Search(string title)
        {
           

            var posts = await _postService.GetAllPostsAsync(title);
           

            return Ok(new Response<IEnumerable<PostDto>>(posts));
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

            return Ok(new Response<PostDto>(post));
        }

        [SwaggerOperation(Summary = "Create a new post")]
        [HttpPost]
        public async Task<IActionResult> Create(CreatePostDto newPost)
        {
            var post = await _postService.AddNewPostAsync(newPost);

            return Created(uri: $"api/posts/{post.Id}", new Response<PostDto>(post));
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
