using BulkyBookModel;
using BulkyBookSolution.BulkyBookModel.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookSolution.BulkyBookDataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        //Create Dbset for Categories Table
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ProductModel> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Add Data Into Categories Table
            modelBuilder.Entity<CategoryModel>().HasData(
                new CategoryModel { CategoryID = 1 , CategoryName = "Action", CategoryDisplayOrder = 1},
                new CategoryModel { CategoryID = 2, CategoryName = "Sci-Fi", CategoryDisplayOrder = 2 },
                new CategoryModel { CategoryID = 3, CategoryName = "Histroy", CategoryDisplayOrder = 3 }
                );

            //Add Data Into Product Table
            modelBuilder.Entity<ProductModel>().HasData(
              new ProductModel
              {
                  ProductID = 1,
                  ProductTitle = "Fortune of Time",
                  ProductAuthor = "Billy Spark",
                  ProductDescription = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincProductIDunt. ",
                  ProductISBN = "SWD9999001",
                  ProductListPrice = 99,
                  ProductPriceOneToFifty = 90,
                  ProductPriceFiftyPlus = 85,
                  ProductPriceHundredPlus = 80,
                  CategoryID=1
              },
                new ProductModel
                {
                    ProductID = 2,
                    ProductTitle = "Dark Skies",
                    ProductAuthor = "Nancy Hoover",
                    ProductDescription = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincProductIDunt. ",
                    ProductISBN = "CAW777777701",
                    ProductListPrice = 40,
                    ProductPriceOneToFifty = 30,
                    ProductPriceFiftyPlus = 25,
                    ProductPriceHundredPlus = 20,
                    CategoryID=1,
                    ProductImgUrl=""
                },
                new ProductModel
                {
                    ProductID = 3,
                    ProductTitle = "Vanish in the Sunset",
                    ProductAuthor = "Julian Button",
                    ProductDescription = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincProductIDunt. ",
                    ProductISBN = "RITO5555501",
                    ProductListPrice = 55,
                    ProductPriceOneToFifty = 50,
                    ProductPriceFiftyPlus = 40,
                    ProductPriceHundredPlus = 35,
                    CategoryID=2,
                    ProductImgUrl = ""
                },
                new ProductModel
                {
                    ProductID = 4,
                    ProductTitle = "Cotton Candy",
                    ProductAuthor = "Abby Muscles",
                    ProductDescription = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincProductIDunt. ",
                    ProductISBN = "WS3333333301",
                    ProductListPrice = 70,
                    ProductPriceOneToFifty = 65,
                    ProductPriceFiftyPlus = 60,
                    ProductPriceHundredPlus = 55,
                    CategoryID=3,
                    ProductImgUrl = ""
                },
                new ProductModel
                {
                    ProductID = 5,
                    ProductTitle = "Rock in the Ocean",
                    ProductAuthor = "Ron Parker",
                    ProductDescription = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincProductIDunt. ",
                    ProductISBN = "SOTJ1111111101",
                    ProductListPrice = 30,
                    ProductPriceOneToFifty = 27,
                    ProductPriceFiftyPlus = 25,
                    ProductPriceHundredPlus = 20,
                    CategoryID=2,
                    ProductImgUrl = ""
                },
                new ProductModel
                {
                    ProductID = 6,
                    ProductTitle = "Leaves and Wonders",
                    ProductAuthor = "Laura Phantom",
                    ProductDescription = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincProductIDunt. ",
                    ProductISBN = "FOT000000001",
                    ProductListPrice = 25,
                    ProductPriceOneToFifty = 23,
                    ProductPriceFiftyPlus = 22,
                    ProductPriceHundredPlus = 20,
                    CategoryID=3,
                    ProductImgUrl = ""
                }
               );
        }
    }
}
