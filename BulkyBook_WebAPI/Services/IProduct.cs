using BulkyBook_WebAPI.Model;

namespace BulkyBook_WebAPI.Services
{
    public interface IProduct : IServices<Product>
    {
        void UpdateProduct(Product product);
    }
    
}
