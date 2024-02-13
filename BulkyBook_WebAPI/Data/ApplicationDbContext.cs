using BulkyBook_WebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook_WebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        // DbSet representing the Category table in the database
       public DbSet<Category> CategoriesDetalis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>(CategoryEntity =>
            {
                // Configuring primary key
                CategoryEntity.HasKey(e => e.CategoryID);
                CategoryEntity.ToTable("Categories");

                // Configuring properties for the Category entity
                CategoryEntity.Property(e => e.CategoryName).HasMaxLength(int.MaxValue);
                CategoryEntity.Property(e=> e.CategoryDisplayOrder).HasColumnName("CategoryDisplayOrder");

            });
        }
    }
}
