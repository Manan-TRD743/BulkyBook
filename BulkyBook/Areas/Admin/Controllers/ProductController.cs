using BulkyBookDataAccess.Repository;
using BulkyBookDataAccess.Repository.IRepository;
using BulkyBookModel;
using BulkyBookModel.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork ProductUnitOfWork;
        private readonly IWebHostEnvironment ProductWebHostEnvironment;

        public ProductController(IUnitOfWork UnitOfWorkProduct, IWebHostEnvironment webHostEnvironment)
        {
            ProductUnitOfWork = UnitOfWorkProduct;
            ProductWebHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<ProductModel> objProductList = ProductUnitOfWork.Product.GetAll().ToList();
            
            return View(objProductList);
        }

        #region CreateNewProduct
        public IActionResult UpsertProduct(int? id)
        {
            IEnumerable<SelectListItem> categorylist = ProductUnitOfWork.Category.GetAll().
                Select(u => new SelectListItem
                {
                    Text = u.CategoryName,
                    Value = u.CategoryID.ToString()
                });

            ViewBag.CategoryList = categorylist;

            ProductViewModel productViewModel = new()
            {
                CategoryList = categorylist,
                Product = new ProductModel()
            };
            if(id==null || id == 0)
            {
                //Create Product
                return View(productViewModel);
            }
            else
            {
                //Update Product
                productViewModel.Product = ProductUnitOfWork.Product.Get(u=>u.ProductID ==  id);
                return View(productViewModel);
            }
          
        }

        [HttpPost]
        public IActionResult UpsertProduct(ProductViewModel ProductVM,IFormFile? file )
        {
            if (ProductVM != null)
            {
                if (ModelState.IsValid)
                {
                    string WwwRootPath = ProductWebHostEnvironment.WebRootPath;

                    if(file != null)
                    {
                        string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string productpath = Path.Combine(WwwRootPath, @"Images\Product");
                        using (var fileStream = new FileStream(Path.Combine(productpath, filename), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }


                        ProductVM.Product.ProductImgUrl = @"\Images\Product\" + filename;
                    }
                    

                    ProductUnitOfWork.Product.Add(ProductVM.Product);
                    ProductUnitOfWork.Save();
                    TempData["Success"] = "New Product Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ProductVM.CategoryList = ProductUnitOfWork.Category.GetAll().
                         Select(u => new SelectListItem
                         {
                             Text = u.CategoryName,
                             Value = u.CategoryID.ToString()
                         });
                    return View(ProductVM);
                }
               
            }
            else
            {
                return NotFound();
            }

        }
        #endregion


        #region Delete Product
        public IActionResult DeleteProduct(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            ProductModel? ProductFromDb = ProductUnitOfWork.Product.Get(u => u.ProductID == id);
            if (ProductFromDb == null)
            {
                return NotFound();
            }
            return View(ProductFromDb);
        }

        [HttpPost, ActionName("DeleteProduct")]
        public IActionResult DeleteCategoryPost(ProductModel obj)
        {
            ProductUnitOfWork.Product.Remove(obj);
            ProductUnitOfWork.Save();
            TempData["Success"] = "Product Deleted Successfully";
            return RedirectToAction("Index");
        }
        #endregion
    }
}
