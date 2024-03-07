using BulkyBookDataAccess.Repository.IRepository;
using BulkyBookModel;
using BulkyBookModel.ViewModel;
using BulkyBookUtility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    // Authorize access only for users with "Admin" role
    [Authorize(Roles = StaticData.RoleUserAdmin)]
    public class ReportController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        [BindProperty]
        public OrderViewModel objOrderVM { get; set; }


        public ReportController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }
        public IActionResult OrderReport()
        {
            return View();
        }
        public IActionResult TransactionReport()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetOrderReport(DateTime StartDate, DateTime EndDate)
        {
             IEnumerable<OrderHeaderModel> objorderHeaders = _UnitOfWork.OrderHeader
            .GetAll(includeProperties: "ApplicationUser")
            .Where(u => u.OrderDate >= StartDate && u.OrderDate <= EndDate)
            .ToList();
                return Json(new { Data = objorderHeaders });
            
        }

        [HttpGet]
        public IActionResult GetTransactionReport(DateTime StartDate, DateTime EndDate)
        {
            DateTime startDateFormatted = StartDate.Date;
            DateTime endDateFormatted = EndDate.Date.AddDays(1).AddMilliseconds(-1);
            IEnumerable<OrderHeaderModel> objorderHeaders = _UnitOfWork.OrderHeader
           .GetAll(includeProperties: "ApplicationUser")
           .Where(u => u.PaymentDate >= startDateFormatted && u.PaymentDate <= endDateFormatted
                  && (u.OrderStatus ==StaticData.StatusApproved || u.OrderStatus==StaticData.StatusShipped || u.OrderStatus == StaticData.StatusInProcess)
                  && (u.PaymentStatus ==StaticData.PaymentStatusApproved))
           .ToList();
            return Json(new { Data = objorderHeaders });

        }
    }
}
