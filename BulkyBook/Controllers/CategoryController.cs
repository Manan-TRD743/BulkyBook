using BulkyBook.Data;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbCategory;

        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbCategory = dbContext;
        }
        public IActionResult Index()
        {
            List<CategoryModel> objCategoryList = _dbCategory.Categories.ToList();
            return View(objCategoryList);
        }

        #region CreateNewCategory
        public IActionResult CreateNewCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNewCategory(CategoryModel obj)
        {
            //Category name and category display order are not the same.
            if (obj.CategoryName == obj.CategoryDisplayOrder.ToString())
            {
                ModelState.AddModelError("CategoryName", "Category name and Display order are not the same.");

            }

            if (ModelState.IsValid)
            {
                _dbCategory.Categories.Add(obj);
                _dbCategory.SaveChanges();
                TempData["Success"] = "New Category Created Successfully";
                return RedirectToAction("Index");
            }
            return View();
            
        }
        #endregion

        #region Edit Category
        public IActionResult EditCategory(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            CategoryModel? CategoryFromDb = _dbCategory.Categories.Find(id);
            if(CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);
        }

        [HttpPost]
        public IActionResult EditCategory(CategoryModel obj)
        {
            if (ModelState.IsValid)
            {
                _dbCategory.Categories.Update(obj);
                _dbCategory.SaveChanges();
                TempData["Success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }
            return View();

        }
        #endregion

        #region Delete Category
        public IActionResult DeleteCategory(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            CategoryModel? CategoryFromDb = _dbCategory.Categories.Find(id);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);
        }

        [HttpPost,ActionName("DeleteCategory")]
        public IActionResult DeleteCategoryPost(CategoryModel obj)
        {
                _dbCategory.Categories.Remove(obj);
                _dbCategory.SaveChanges();
                TempData["Success"] = "Category Deleted Successfully";
                return RedirectToAction("Index");
        }
        #endregion
    }
}
