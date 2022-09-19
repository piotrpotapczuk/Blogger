﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllAsync(int pageNumber, int pageSize);

        Task<int> GetAllCountAsync();
        Task<IEnumerable<Post>> GetAllAsync(string title);
        Task<Post> GetByIdAsync(int id);

        Task<Post> AddAsync(Post post);

        Task UpdateAsync(Post post);
        Task DeleteAsync(Post post);


    }
}
