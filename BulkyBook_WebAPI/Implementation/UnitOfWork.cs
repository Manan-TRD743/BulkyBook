using BulkyBook_WebAPI.Data;
using BulkyBook_WebAPI.Services;

namespace BulkyBook_WebAPI.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategory Category { get; private set; }

        private ApplicationDbContext DbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
            Category = new CategoryImplementation(DbContext);

        }

        public void Save()
        {
            DbContext.SaveChanges();
        }
    }
}
