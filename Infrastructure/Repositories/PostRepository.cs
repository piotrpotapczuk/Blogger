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
            throw new NotImplementedException();
        }

        public Post GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Post Add(Post post)
        {
            throw new NotImplementedException();
        }


        public void Update(Post post)
        {
            throw new NotImplementedException();
        }
        public void Delete(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
