using BulkyBookDataAccess.Repository.IRepository;
using BulkyBookModel;
using BulkyBookSolution.BulkyBookModel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BulkyBook.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger,IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork; 
        }

        public IActionResult Index()
        {
            //Get All Product Details and also include the Details of catgeory which is releted to Product
            IEnumerable<ProductModel> productlist = _unitOfWork.Product.GetAll(includeProperties: "Category");
            return View(productlist);
        }
        public IActionResult ProductDetails(int id)
        {
            //Get Product from id 
            ProductModel product = _unitOfWork.Product.Get(u=>u.ProductID.Equals(id),includeProperties: "Category");
            return View(product);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
