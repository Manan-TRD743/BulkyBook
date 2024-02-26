using BulkyBookDataAccess.Repository.IRepository;
using BulkyBookModel;
using BulkyBookModel.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BulkyBook.Areas.Customer.Controllers
{
    [Area("customer")]
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShoppingCartViewModel ShoppingCartVM { get; set; }

        public ShoppingCartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCartVM = new()
            {
                ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u=>u.ApplicationUserId == userId,includeProperties:"Product")
            };
            foreach(var Cart in ShoppingCartVM.ShoppingCartList)
            {
                Cart.TotalPrice = GetPriceBasedOnQuantity(Cart);
                ShoppingCartVM.OrderTotal += (Cart.TotalPrice * Cart.ProductCount); 
            }

            return View(ShoppingCartVM);
        }

        private double GetPriceBasedOnQuantity(ShoppingCart cart)
        {
            if (cart.ProductCount <= 50)
            {
                return cart.Product.ProductPriceOneToFifty;
            }
            else if(cart.ProductCount <= 100)
            {
                return cart.Product.ProductPriceFiftyPlus;
            }
            else if(cart.ProductCount > 100)
            {
                return cart.Product.ProductPriceHundredPlus;
            }
            else
            {
                return 0;
            }
        }
    }
}
