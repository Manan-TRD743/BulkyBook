using BulkyBookDataAccess.Repository.IRepository;
using BulkyBookSolution.BulkyBookDataAccess.Data;
using BulkyBookSolution.BulkyBookModel.Models;

namespace BulkyBookDataAccess.Repository
{
    public class CategoryRepository : Repository<CategoryModel>, ICategoryRepository
    {
        //Create a ApplicationDbContext Object
        private readonly ApplicationDbContext CategoryDbContext;

        public CategoryRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            //Initialize ApplicationDbContext
            CategoryDbContext = applicationDbContext;
        }

        //Update Method For Category
        public void Update(CategoryModel category)
        {
           CategoryDbContext.Update(category);
        }
    }
}
