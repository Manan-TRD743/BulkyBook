using BulkyBookDataAccess.Repository.IRepository;
using BulkyBookModel;
using BulkyBookModel.ViewModel;
using BulkyBookUtility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        [BindProperty]
        public OrderViewModel objOrderVM { get; set; }


        public OrderController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OrderDetails(int OrderID)
        {
            objOrderVM = new()
            {
                orderHeader = _UnitOfWork.OrderHeader.Get(u => u.OrderHeaderID == OrderID, includeProperties: "ApplicationUser"),
                orderDetails = _UnitOfWork.OrderDetail.GetAll(u => u.OrderHeaderID == OrderID, includeProperties: "Product")
            };
            return View(objOrderVM);
        }

        #region UpdateOrderDetails  
        [HttpPost]
        [Authorize(Roles =StaticData.RoleUserAdmin+","+StaticData.RoleUserEmployee)]
        public IActionResult UpdateOrderDetails()
        {
            var orderHeaderFromDb = _UnitOfWork.OrderHeader.Get(u => u.OrderHeaderID == objOrderVM.orderHeader.OrderHeaderID);

            orderHeaderFromDb.UserName = objOrderVM.orderHeader.UserName;
            orderHeaderFromDb.UserPhoneNumber = objOrderVM.orderHeader.UserPhoneNumber;
            orderHeaderFromDb.UserStreetAddress = objOrderVM.orderHeader.UserStreetAddress;
            orderHeaderFromDb.UserCity = objOrderVM.orderHeader.UserCity;
            orderHeaderFromDb.UserState = objOrderVM.orderHeader.UserState;
            orderHeaderFromDb.UserPostalCode = objOrderVM.orderHeader.UserPostalCode;

            if (!string.IsNullOrEmpty(objOrderVM.orderHeader.Carrier))
            {
                orderHeaderFromDb.Carrier = objOrderVM.orderHeader.Carrier;

            }
            if (!string.IsNullOrEmpty(objOrderVM.orderHeader.TrackingNumber))
            {
                orderHeaderFromDb.TrackingNumber = objOrderVM.orderHeader.TrackingNumber;
            }
            _UnitOfWork.OrderHeader.Update(orderHeaderFromDb);
            _UnitOfWork.Save();

            TempData["success"] = "Order Details Updated Successfully";
            return RedirectToAction(nameof(OrderDetails), new { OrderID = orderHeaderFromDb.OrderHeaderID});
        }

        #endregion
    
        #region GetAll Order (Api Call)
        [HttpGet]
        public IActionResult GetAll(string status)
        {
            IEnumerable<OrderHeaderModel> objorderHeaders = _UnitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser").ToList();
            if(User.IsInRole(StaticData.RoleUserAdmin) || User.IsInRole(StaticData.RoleUserEmployee))
            {
                objorderHeaders = _UnitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser").ToList();
            }
            else
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var userID = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

                objorderHeaders = _UnitOfWork.OrderHeader.GetAll(u=>u.ApplicationUserId==userID,includeProperties: "ApplicationUser");
            }

            switch (status)
            {
                case "inprocess":
                    objorderHeaders = objorderHeaders.Where(u => u.OrderStatus == StaticData.StatusInProcess);
                    break;
                case "pending":
                    objorderHeaders = objorderHeaders.Where(u => u.PaymentStatus == StaticData.PaymentStatusDelayedPayment);
                    break;
                case "completed":
                    objorderHeaders = objorderHeaders.Where(u => u.OrderStatus == StaticData.StatusShipped);
                    break;

                case "approved":
                    objorderHeaders = objorderHeaders.Where(u => u.OrderStatus == StaticData.StatusApproved );
                    break;

                default:
                    break;

            }

            return Json(new { Data = objorderHeaders });
        }
        #endregion

        #region Order Processing
        [HttpPost]
        [Authorize(Roles = StaticData.RoleUserAdmin + "," + StaticData.RoleUserEmployee)]
        public IActionResult StartOrderProcessing()
        {
            _UnitOfWork.OrderHeader.UpdateStatus(objOrderVM.orderHeader.OrderHeaderID, StaticData.StatusInProcess);
            _UnitOfWork.Save();
            TempData["success"] = "Now OrderStatus is in Processing";
            return RedirectToAction(nameof(OrderDetails), new { OrderID = objOrderVM.orderHeader.OrderHeaderID });
        }
        #endregion

        #region Order Shipping
        [HttpPost]
        [Authorize(Roles = StaticData.RoleUserAdmin + "," + StaticData.RoleUserEmployee)]
        public IActionResult OrderShipping()
        {
            var orderheader = _UnitOfWork.OrderHeader.Get(u => u.OrderHeaderID == objOrderVM.orderHeader.OrderHeaderID);
            orderheader.TrackingNumber = objOrderVM.orderHeader.TrackingNumber;
            orderheader.Carrier = objOrderVM.orderHeader.Carrier;
            orderheader.OrderStatus =StaticData.StatusShipped;
            orderheader.ShippingDate = DateOnly.FromDateTime(DateTime.Now);
            if(orderheader.PaymentStatus == StaticData.PaymentStatusDelayedPayment)
            {
                orderheader.PaymentDueDate = DateOnly.FromDateTime(DateTime.Now.AddDays(30));
            }
            _UnitOfWork.OrderHeader.Update(orderheader);
            _UnitOfWork.Save();

            TempData["success"] = "Order Shipped Successfully.";
            return RedirectToAction(nameof(OrderDetails), new { OrderID = objOrderVM.orderHeader.OrderHeaderID });
        }
        #endregion

    }
}
