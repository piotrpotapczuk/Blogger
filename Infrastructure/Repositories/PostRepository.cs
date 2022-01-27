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
            new Post
            {
                Id = 1,
                Title = "Jak zostać programistą",
                Content = "Content 1",
            },
            new Post()
            {
                Id = 2,
                Title = "Ile zarabia programista",
                Content = "Content 2",
            },
            new Post(3, "Dlaczegp warto zostać programistą", "Content 3"),
            new Post(4, "Title 4", "Content 4")
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
            post.Id = _posts.Count() + 1;
            post.Created = DateTime.UtcNow;
            _posts.Add(post);
            return post;    
        }

        public void Update(Post post)
        {
            post.LastModified = DateTime.UtcNow;
        }
    

        public void Delete(Post post)
        {
            _posts.Remove(post);
        }

     
    }
}
