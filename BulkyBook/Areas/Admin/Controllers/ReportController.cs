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
        #region Get Order Report
        [HttpGet]
        public IActionResult GetOrderReport(DateTime StartDate, DateTime EndDate)
        {
            IEnumerable<OrderHeaderModel> objorderHeaders = _UnitOfWork.OrderHeader
            .GetAll(includeProperties: "ApplicationUser")
            .Where(u => u.OrderDate.Date >= StartDate.Date && u.OrderDate.Date <= EndDate.Date)
            .ToList();
                return Json(new { Data = objorderHeaders });
            
        }
        #endregion

        #region Get Transaction Report
        [HttpGet]
        public IActionResult GetTransactionReport(DateTime StartDate, DateTime EndDate)
        {
            IEnumerable<OrderHeaderModel> objorderHeaders = _UnitOfWork.OrderHeader
           .GetAll(includeProperties: "ApplicationUser")
           .Where(u => u.PaymentDate.Date >= StartDate.Date && u.PaymentDate.Date <= EndDate.Date
                  && (u.OrderStatus ==StaticData.StatusApproved || u.OrderStatus==StaticData.StatusShipped || u.OrderStatus == StaticData.StatusInProcess)
                  && (u.PaymentStatus ==StaticData.PaymentStatusApproved))
           .ToList();
            return Json(new { Data = objorderHeaders });

        }
        #endregion
    }
}
