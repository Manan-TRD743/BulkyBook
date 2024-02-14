using BulkyBookDataAccess.Repository.IRepository;
using BulkyBookSolution.BulkyBookDataAccess.Data;

namespace BulkyBookDataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; private set; }
        private readonly ApplicationDbContext CategoryDbContext;

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            CategoryDbContext = applicationDbContext;
            CategoryRepository = new CategoryRepository(CategoryDbContext);
        } 
        public void Save()
        {
            CategoryDbContext.SaveChanges();
        }
    }
}
