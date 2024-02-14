using BulkyBookSolution.BulkyBookModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBookDataAccess.Repository.IRepository
{
    public interface ICategoryRepository : Irepository<CategoryModel>
    {
        void Update(CategoryModel category);
    }
}
