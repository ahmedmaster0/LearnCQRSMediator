using Domain;
using Domain.EntityTypeConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence
{
    public class ApplicationContext : IdentityDbContext
    {
        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; } 


        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PostConfigurations());
            builder.ApplyConfiguration(new CategoryConfigurations());

            builder.Entity<Category>().HasData(new Category
            {
                Id = Guid.NewGuid(),
                Name = "Love",
            });


            base.OnModelCreating(builder);
        }
    }
}
