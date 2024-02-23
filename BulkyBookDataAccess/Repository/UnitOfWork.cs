using BulkyBookDataAccess.Repository.IRepository;
using BulkyBookSolution.BulkyBookDataAccess.Data;

namespace BulkyBookDataAccess.Repository
{
    //Implement IUnitOfWork Interface
    public class UnitOfWork : IUnitOfWork
    {
        // Declare properties for each repository that will be used in the unit of work
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public ICompanyRepository Company { get; private set; }

        //Define a ApplicationDbContext for interact with Database
        private ApplicationDbContext DbContext;

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            // Set the DbContext 
            DbContext = applicationDbContext;

            // Initialize each repository with the DbContext
            Category = new CategoryRepository(DbContext);
            Product = new ProductRepository(DbContext);
            Company = new CompanyRepository(DbContext);
        }


        // Define a method called Save that saves all changes made to the database
        public void Save()
        {
            DbContext.SaveChanges();
        }
    }
}
