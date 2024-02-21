using BulkyBookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBookDataAccess.Repository.IRepository
{
    public interface ICompanyRepository : Irepository<CompanyModel>
    {
        void UpdateCompany(CompanyModel company);
    }
}
