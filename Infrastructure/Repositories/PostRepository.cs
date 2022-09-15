using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private static readonly ISet<Post> _posts = new HashSet<Post>()
        {
            new Post(1,"Title1","Content1"),
            new Post(2,"Title1","Content2"),
            new Post(3,"Title3","Content3")

        };

        public IEnumerable<Post> GetAll()
        {
            return _posts;
        }

        public Post GetById(int id)
        {
            return _posts.SingleOrDefault(p => p.Id == id);
        }

        public Post Add(Post post)
        {
            
            post.Id = _posts.Count + 1;
            post.Created = DateTime.Now;

            _posts.Add(post);

            return post;
        }


        public void Update(Post post)
        {
            post.LastModified = DateTime.Now;
            post.LastModifiedBy = "Admin";

        }
        public void Delete(Post post)
        {
            _posts.Remove(post);    
        }
    }
}
