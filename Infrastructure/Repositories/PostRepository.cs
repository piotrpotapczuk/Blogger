using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.ExtensionMethods;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        /*
        private static readonly ISet<Post> _posts = new HashSet<Post>()
        {
            new Post(1,"Title1","Content1"),
            new Post(2,"Title1","Content2"),
            new Post(3,"Title3","Content3")

        };*/

        private readonly BloggerContext _context;

        public PostRepository(BloggerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Post>> GetAllAsync(int pageNumber, int pageSize, string sortField, bool ascending)
        {
            return await _context.Posts.OrderByPropertyName(sortField, ascending).Skip((pageNumber-1)* pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetAllAsync(string title)
        {

            return await _context.Posts.Where(p => p.Title.ToLower() == title.ToLower()).OrderByDescending(p => p.Id).ToListAsync();
        }
        public async Task<int> GetAllCountAsync()
        {
            return await _context.Posts.CountAsync();
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            return await _context.Posts.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Post> AddAsync(Post post)
        {

            var createdPost = await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();

            return createdPost.Entity;
        }


        public async Task UpdateAsync(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Post post)
        {
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

    }
}
