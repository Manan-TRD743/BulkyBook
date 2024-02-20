using BulkyBook_WebAPI.Model;

namespace BulkyBook_WebAPI.Services
{
    public interface ICategory : IServices<Category>
    {
        void UpdateCategory(Category category);
    }
}
