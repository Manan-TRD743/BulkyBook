using BulkyBook_WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork UnitOfWorkObj;
        public ProductController(IUnitOfWork unitOfWork)
        {
            UnitOfWorkObj = unitOfWork;
        }
        #region GetData
        // GET: api/Product
        [HttpGet]
        public IActionResult GetProduct()
        {
            try
            {
                // Retrieve all Product from the database
                var GetProduct = UnitOfWorkObj.Product.GetAll();
                if (GetProduct == null)
                {
                    // Handle the case where Product is null
                    return StatusCode(500, "Failed to retrieve Product from the database.");
                }
                else
                {
                    // Return success response with the list of Product
                    return Ok(new { StatusCode = 200, status = "Success", Products = GetProduct });
                }

            }
            catch (Exception ex)
            {
                // Return error response with 500 status code
                return StatusCode(500, new { error = "Internal Server Error : " + ex.Message });
            }
        }


        // GET: api/Product/5
        [HttpPost("{id}")]
        public IActionResult GetProductById(int id)
        {

            try
            {
                if (id < 1)
                {
                    // Bad request if id is invalid
                    return BadRequest(new { StatusCode = 400, Message = "Bad Request" });
                }
                // Retrieve a specific Product by id
                var Product = UnitOfWorkObj.Product.Get(u => u.ProductID.Equals(id));
                if (Product == null)
                {
                    // Return NotFound if the Product is not found
                    return NotFound(new { StatusCode = 404, Message = "Not Found" });
                }
                // Return the Product if found
                return Ok(new { StatusCode = 200, status = "Success", categories = Product });
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
