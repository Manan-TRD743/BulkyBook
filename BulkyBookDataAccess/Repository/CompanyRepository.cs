using BulkyBookDataAccess.Repository.IRepository;
using BulkyBookModel;
using BulkyBookSolution.BulkyBookDataAccess.Data;

namespace BulkyBookDataAccess.Repository
{
    public class CompanyRepository : Repository<CompanyModel>, ICompanyRepository
    {
        private ApplicationDbContext dbContext;

        public CompanyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public void UpdateCompany(CompanyModel company)
        {
            dbContext.Companies.Update(company);
        }
    }
}
