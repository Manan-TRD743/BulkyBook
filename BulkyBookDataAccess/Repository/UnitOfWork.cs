using BulkyBookDataAccess.Repository.IRepository;
using BulkyBookSolution.BulkyBookDataAccess.Data;

namespace BulkyBookDataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }

        private ApplicationDbContext DbContext;

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            DbContext = applicationDbContext;
            Category = new CategoryRepository(DbContext);
            Product = new ProductRepository(DbContext);
        } 
        public void Save()
        {
            DbContext.SaveChanges();
        }
    }
}
