using BulkyBook_WebAPI.Model;

namespace BulkyBook_WebAPI.Services
{
  /*  public interface IProduct : IServices<Product>
    {
        void UpdateProduct(Product product);
    }*/
    
    public interface IProduct 
    {
        Task AddProductAsync(Product Product);
        Task UpdateProductAsync(Product Product);
        Task DeleteProductAsync(Product Product);
        Task<List<Product>> GetAllProductAsync();
        Task<Product> GetProductAsync(int? ProductID);
        Task SaveProductAsync();

    }
}
