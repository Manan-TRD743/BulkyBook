using BulkyBook_WebAPI.Data;
using BulkyBook_WebAPI.Model;
using BulkyBook_WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook_WebAPI.Implementation
{
    public class ProductCrudOperation : IProduct
    {
        private readonly ApplicationDbContext DbSet;
        private readonly IWebHostEnvironment WebHostEnvironment;

        // Constructor to initialize the database context
        public ProductCrudOperation(ApplicationDbContext dbContext)
        {
            DbSet = dbContext;
        }

        #region Add Product
        public async Task AddProductAsync(Product Product)
        {
            try
            {
                // Check if the category already exists
                var existingCategory = await DbSet.CategoriesDetalis.FirstOrDefaultAsync(c => c.CategoryName!.Equals(Product.Category!.CategoryName));
                if (existingCategory == null)
                {
                    // Add the new category to the database
                    DbSet.CategoriesDetalis.Add(Product.Category!); // Add the category associated with the product
                }

                // Assign the existing or new category to the product
                Product.Category = existingCategory;

                // Add the product to the database
                DbSet.Add(Product);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("Error occurred while adding product: " + ex.Message);
            }
        }
        #endregion

        #region Delete Product
        public async Task DeleteProductAsync(Product Product)
        {
            await Task.Run(() =>
            {
                DbSet.Remove(Product);
            });
        }
        #endregion

        #region Get All Product
        public async Task<List<Product>> GetAllProductAsync()
        {
            return await DbSet.Products.Include(c=>c.Category).ToListAsync();
        }
        #endregion

        #region Get Product from Id
        public async Task<Product> GetProductAsync(int? ProductID)
        {
            var product = await DbSet.Set<Product>()
                               .Where(u => u.ProductID.Equals(ProductID))
                               .FirstOrDefaultAsync();

            // If no product is found, throw an exception
            return product ?? throw new InvalidOperationException("Product not found");
        }
        #endregion

        #region Save Product
        public async Task SaveProductAsync()
        {
            await DbSet.SaveChangesAsync();
        }
        #endregion

        #region Update Product
        public async Task UpdateProductAsync(Product Product)
        {

            // Check if the category already exists
            var existingCategory = await DbSet.CategoriesDetalis.FirstOrDefaultAsync(c => c.CategoryName!.Equals(Product.Category!.CategoryName));
            if (existingCategory == null)
            {
                // Add the new category to the database
                DbSet.CategoriesDetalis.Add(Product.Category!); // Add the category associated with the product
            }

            // Assign the existing or new category to the product
            Product.Category = existingCategory;

            await Task.Run(() =>
            {
                DbSet.Update(Product);
            });
        }
        #endregion

    }
}
