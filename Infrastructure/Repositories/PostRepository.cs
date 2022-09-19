using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
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

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts;
        }

        public IEnumerable<Post> GetAll(string title)
        {

            return _context.Posts.Where(p => p.Title.ToLower() == title.ToLower()).OrderByDescending(p => p.Id);
        }

        public Post GetById(int id)
        {
            return _context.Posts.SingleOrDefault(p => p.Id == id);
        }

        public Post Add(Post post)
        {

            _context.Posts.Add(post);
            _context.SaveChanges();

            return post;
        }


        public void Update(Post post)
        {
            _context.Posts.Update(post);
            _context.SaveChanges();

        }
        public void Delete(Post post)
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }

       
    }
}
