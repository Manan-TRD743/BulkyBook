using BulkyBookDataAccess.Repository.IRepository;
using BulkyBookModel;
using BulkyBookSolution.BulkyBookDataAccess.Data;

namespace BulkyBookDataAccess.Repository
{
    public class CompanyRepository : Repository<CompanyModel>, ICompanyRepository
    {
        //Create a ApplicationDbContext Object
        private ApplicationDbContext dbContext;

        public CompanyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            //Initialize ApplicationDbContext
            this.dbContext = dbContext;
        }

       //Update Method For Company
        public void UpdateCompany(CompanyModel company)
        {
            dbContext.Companies.Update(company);
        }
    }
}
