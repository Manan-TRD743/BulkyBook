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

        public void Update(ProductModel Productmodel)
        {
            var productFromDb =  ProductDbContext.Products.FirstOrDefault(u=>u.ProductID == Productmodel.ProductID);

            if(productFromDb != null)
            {
                productFromDb.ProductTitle = Productmodel.ProductTitle;
                productFromDb.ProductISBN = Productmodel.ProductISBN;
                productFromDb.ProductListPrice = Productmodel.ProductListPrice;
                productFromDb.ProductPriceFiftyPlus = Productmodel.ProductPriceFiftyPlus;
                productFromDb.ProductPriceHundredPlus = Productmodel.ProductPriceHundredPlus;
                productFromDb.ProductDescription = Productmodel.ProductDescription;
                productFromDb.CategoryID = Productmodel.CategoryID;
                productFromDb.ProductAuthor = Productmodel.ProductAuthor;
                if (Productmodel.ProductImgUrl != null)
                {
                    productFromDb.ProductImgUrl = Productmodel.ProductImgUrl;
                }
            }
        }
    }
}
