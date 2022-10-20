using Application.Dto;
using Cosmonaut;
using Cosmonaut.Extensions;
using Domain.Entities;
using Domain.Entities.Cosmos;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Repositories
{
    public class CosmosPostRepository : ICosmosPostRepository
    {
        private readonly ICosmosStore<CosmosPost> _cosmosStore;

        public CosmosPostRepository(ICosmosStore<CosmosPost> cosmosStore)
        {
            _cosmosStore = cosmosStore;
        }

        public async Task<IEnumerable<CosmosPost>> GetAllAsync()
        {
            var posts =  _cosmosStore.Query().ToList(); ;

            return posts;
        }

        public async Task<IEnumerable<CosmosPost>> GetAllAsync(string title)
        {
            throw new NotImplementedException();
        }

        public async Task<CosmosPost> GetByIdAsync(string id)
        {
            var post = await _cosmosStore.FindAsync(id);
            return post;
        }
        public async Task<CosmosPost> AddAsync(CosmosPost post)
        {
            post.Id = Guid.NewGuid().ToString();
            return await _cosmosStore.AddAsync(post);
        }
        public async Task UpdateAsync(CosmosPost post)
        {
           await _cosmosStore.UpdateAsync(post);
        }

        public async Task DeleteAsync(CosmosPost post)
        {
            await _cosmosStore.RemoveAsync(post);
        }

 
    
    }
}
