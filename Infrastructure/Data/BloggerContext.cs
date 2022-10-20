using Application.Services;
using Domain.Common;
using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class BloggerContext : IdentityDbContext<ApplicationUser>
    {
        private readonly UserResolverService _userService;
        public BloggerContext(DbContextOptions<BloggerContext> options, UserResolverService userService) : base(options)
        {
            _userService = userService;
        }

        public DbSet<Post> Posts { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is AuditableEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                (entry.Entity as AuditableEntity).LastModified = DateTime.UtcNow;
                (entry.Entity as AuditableEntity).LastModifiedBy = _userService.GetUser();

                if (entry.State == EntityState.Added)
                {
                    (entry.Entity as AuditableEntity).Created = DateTime.UtcNow;
                    (entry.Entity as AuditableEntity).CreatedBy = _userService.GetUser();
                }

            }

            return await base.SaveChangesAsync();
        }


    }
}
