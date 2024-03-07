using BulkyBookSolution.BulkyBookModel.Models;

namespace BulkyBookDataAccess.Repository.IRepository
{
    public interface ICategoryRepository : Irepository<CategoryModel>
    {
        //Declaration Of Methos for Update Category 
        void Update(CategoryModel category);
    }
}
