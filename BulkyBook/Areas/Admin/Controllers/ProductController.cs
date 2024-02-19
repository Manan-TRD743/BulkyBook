using BulkyBookDataAccess.Repository;
using BulkyBookDataAccess.Repository.IRepository;
using BulkyBookModel;
using BulkyBookModel.ViewModel;
using BulkyBookUtility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticData.RoleUserAdmin)]
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
            List<ProductModel> objProductList = ProductUnitOfWork.Product.GetAll(includeProperties: "Category").ToList();
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

                        if(!string.IsNullOrEmpty(ProductVM.Product.ProductImgUrl))
                        {
                            //Delete Old Image
                            var OldImgPath = Path.Combine(WwwRootPath,                            ProductVM.Product.ProductImgUrl.TrimStart('\\')); 
                            if(System.IO.File.Exists(OldImgPath))
                            {
                                System.IO.File.Delete(OldImgPath);
                            }
                        }
                        using (var fileStream = new FileStream(Path.Combine(productpath, filename), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }


                        ProductVM.Product.ProductImgUrl = @"\Images\Product\" + filename;
                    }
                    
                    if(ProductVM.Product.ProductID == 0)
                    {
                        //Add Product
                        ProductUnitOfWork.Product.Add(ProductVM.Product);
                        ProductUnitOfWork.Save();
                        TempData["Success"] = "New Product Created Successfully";
                    }
                    else
                    {
                        //Add Product
                        ProductUnitOfWork.Product.Update(ProductVM.Product);
                        ProductUnitOfWork.Save();
                        TempData["Success"] = "Product Updated Successfully";
                    }
                  
                    
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

        #region API Call
        [HttpGet]
        public IActionResult GetAll()
        {
            List<ProductModel> productlist = ProductUnitOfWork.Product.GetAll(includeProperties: "Category").ToList();
            return Json(new {Data = productlist});
        }
        #endregion

        #region Delete Product
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            ProductModel ProductToBeDelelted = ProductUnitOfWork.Product.Get(u => u.ProductID == id);
            if(ProductToBeDelelted == null)
            {
                return Json( new  { sucess = false,message="Error While Deleting" } );
            }
           if(ProductToBeDelelted.ProductImgUrl == null)
            {
                ProductUnitOfWork.Product.Remove(ProductToBeDelelted);
                ProductUnitOfWork.Save();
                return Json(new { sucess = true, message = "Delete Sucessfully" });
            }
            else
            {
                var oldImgPath = Path.Combine(ProductWebHostEnvironment.WebRootPath, ProductToBeDelelted.ProductImgUrl!.TrimStart('\\'));

                if (System.IO.File.Exists(oldImgPath))
                {
                    System.IO.File.Delete(oldImgPath);
                }
                ProductUnitOfWork.Product.Remove(ProductToBeDelelted);
                ProductUnitOfWork.Save();
                return Json(new { sucess = true, message = "Delete Sucessfully" });
            }
                
            }
           
        }
        #endregion
    }

