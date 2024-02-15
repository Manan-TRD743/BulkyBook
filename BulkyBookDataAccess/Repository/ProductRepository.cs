using BulkyBookDataAccess.Repository.IRepository;
using BulkyBookModel;
using BulkyBookSolution.BulkyBookDataAccess.Data;
using BulkyBookSolution.BulkyBookModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBookDataAccess.Repository
{
    public class ProductRepository : Repository<ProductModel>, IProductRepository
    {
        private readonly ApplicationDbContext ProductDbContext;

        public ProductRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            ProductDbContext = applicationDbContext;
        }

        public void Update(ProductModel Product)
        {
            ProductDbContext.Update(Product);
        }
    }
}
