using BulkyBook_WebAPI.Data;
using BulkyBook_WebAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext context;
        public CategoryController(ApplicationDbContext context)
        {
            this.context = context;
        }

        #region GetData
        // GET: api/Category
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                // Retrieve all Category from the database
                var getcategory = await context.CategoriesDetalis.ToListAsync();
                if (getcategory == null)
                {
                    // Handle the case where Category is null
                    return StatusCode(500, "Failed to retrieve Category from the database.");
                }
                else
                {
                    // Return success response with the list of Category
                    return Ok(new { StatusCode = 200, status = "Success", Categories = getcategory });
                }

            }
            catch (Exception ex)
            {
                // Return error response with 500 status code
                return StatusCode(500, new { error = "Internal Server Error : " + ex.Message });
            }
        }


        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            try
            {
                if (id < 1)
                {
                    // Bad request if id is invalid
                    return BadRequest(new { StatusCode = 400, Message = "Bad Request" });
                }
                // Retrieve a specific Category by id
                var category = await context.CategoriesDetalis.SingleOrDefaultAsync(m => m.CategoryID == id);
                if (category == null)
                {
                    // Return NotFound if the Category is not found
                    return NotFound(new { StatusCode = 404, Message = "Not Found" });
                }
                // Return the Category if found
                return Ok(new { StatusCode = 200, status = "Success", categories = category });
            }
            catch (Exception ex)
            {
                // Return error response with 500 status code
                return StatusCode(500, new { error = "Internal Server Error : " + ex.Message });
            }

        }
        #endregion

        #region Add Data
        // POST: api/Categorys
        [HttpPost]
        public async Task<IActionResult> Post(Category Category)
        {
            try
            {
                if (Category == null)
                {
                    return NotFound(new { StatusCode = 404, Status = "Category not found" });
                }
                context.Add(Category);
                await context.SaveChangesAsync();
                return Ok(new { StatusCode = 200, status = "Success", Categorys = Category });
            }
            catch (Exception ex)
            {
                // Return error response with 500 status code
                return StatusCode(500, new { error = "Internal Server Error : " + ex.Message });
            }
        }
        #endregion

        #region Update Data
        // PUT: api/Categorys
        [HttpPut]
        public async Task<IActionResult> Put(Category CategoryData)
        {
            try
            {
                if (CategoryData == null || CategoryData.CategoryID == 0)
                {
                    // Bad request if CategoryData is null or has an invalid CategoryId
                    return BadRequest(new { StatusCode = 400, Message = "Bad Request" });
                }
                // Find the existing Category by CategoryId
                var updateCategory = await context.CategoriesDetalis.FindAsync(CategoryData.CategoryID);
                if (updateCategory == null)
                {
                    // Return NotFound if the Category to update is not found
                    return NotFound(new { StatusCode = 404, Message = "Not Found" });
                }
                // Update the Category properties and save changes
                updateCategory.CategoryName = CategoryData.CategoryName;
                updateCategory.CategoryDisplayOrder = CategoryData.CategoryDisplayOrder;
                

                await context.SaveChangesAsync();
                return Ok(new { StatusCode = 200, status = "Success", Categorys = CategoryData });

            }
            catch (Exception ex)
            {
                // Return error response with 500 status code
                return StatusCode(500, new { error = "Internal Server Error : " + ex.Message });
            }
        }
        #endregion

        #region Delete Data
        // DELETE: api/Categorys/5
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id < 1)
                {
                    // Bad request if id is invalid
                    return BadRequest(new { StatusCode = 400, Message = "Bad Request" });
                }
                // Find the Category to delete by id
                var DeleteCategory = await context.CategoriesDetalis.FindAsync(id);
                if (DeleteCategory == null)
                {
                    // Return NotFound if the Category to delete is not found
                    return NotFound(new { StatusCode = 404, Message = "Not Found" });
                }
                // Remove the Category and save changes
                context.CategoriesDetalis.Remove(DeleteCategory);
                await context.SaveChangesAsync();
                return Ok(new { StatusCode = 200, status = "Success" });

            }
            catch (Exception ex)
            {
                // Return error response with 500 status code
                return StatusCode(500, new { error = "Internal Server Error : " + ex.Message });
            }


        }
        #endregion
    }

}
