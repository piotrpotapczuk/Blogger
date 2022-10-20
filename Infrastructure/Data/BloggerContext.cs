using Domain.Common;
using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class BloggerContext : IdentityDbContext<ApplicationUser>
    {
        public BloggerContext(DbContextOptions<BloggerContext> options) : base(options)
        {
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
                (entry.Entity as AuditableEntity).LastModifiedBy = "Admin";

                if (entry.State == EntityState.Added)
                {
                    (entry.Entity as AuditableEntity).Created = DateTime.UtcNow;
                    (entry.Entity as AuditableEntity).CreatedBy = "Admin";
                }

            }

            return await base.SaveChangesAsync();
        }


    }
}
