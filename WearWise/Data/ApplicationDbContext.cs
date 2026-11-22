
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WearWise.Models;

namespace WearWise.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Men" },
                new Category { Id = 2, Name = "Women" },
                new Category { Id = 3, Name = "Shoes" },
                new Category { Id = 4, Name = "Accessories" }
            );
        }
    }
}
