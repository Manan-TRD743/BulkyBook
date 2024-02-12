using BulkyBook.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        //Create Dbset for Categories Table
        public DbSet<CategoryModel> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Add Data Into Categories Table
            modelBuilder.Entity<CategoryModel>().HasData(
                new CategoryModel { CategoryID = 1 , CategoryName = "Action", CategoryDisplayOrder = 1},
                new CategoryModel { CategoryID = 2, CategoryName = "Sci-Fi", CategoryDisplayOrder = 2 },
                new CategoryModel { CategoryID = 3, CategoryName = "Histroy", CategoryDisplayOrder = 3 }
                );

        }
    }
}
