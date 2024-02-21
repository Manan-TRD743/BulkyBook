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
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork CompanyUnitOfWork;
        private readonly IWebHostEnvironment CompanyWebHostEnvironment;

        public CompanyController(IUnitOfWork UnitOfWorkCompany, IWebHostEnvironment webHostEnvironment)
        {
            CompanyUnitOfWork = UnitOfWorkCompany;
            CompanyWebHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<CompanyModel> objCompanyList = CompanyUnitOfWork.Company.GetAll().ToList();
                return View(objCompanyList);
        }

        #region CreateNewCompany
        public IActionResult UpsertCompany(int? id)
        {
            if(id==null || id == 0)
            {
                //Create Company
                return View(new CompanyModel());
            }
            else
            {
                //Update Company
                CompanyModel Company = CompanyUnitOfWork.Company.Get(u=>u.CompanyID ==  id);
                return View(Company);
            }
          
        }

        [HttpPost]
        public IActionResult UpsertCompany(CompanyModel Companyobj)
        {
            if (Companyobj != null)
            {
                if (ModelState.IsValid)
                { 
                    if(Companyobj.CompanyID == 0)
                    {
                        //Add Company
                        CompanyUnitOfWork.Company.Add(Companyobj);
                        CompanyUnitOfWork.Save();
                        TempData["Success"] = "New Company Created Successfully";
                    }
                    else
                    {
                        //Add Company
                        CompanyUnitOfWork.Company.UpdateCompany(Companyobj);
                        CompanyUnitOfWork.Save();
                        TempData["Success"] = "Company Details Updated Successfully";
                    }
                  
                    
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(Companyobj);
                }
               
            }
            else
            {
                return NotFound();
            }

        }
        #endregion

        #region GetALl Data
        [HttpGet]
        public IActionResult GetAllCompany()
        {
            
            List<CompanyModel> Companylist = CompanyUnitOfWork.Company.GetAll().ToList();
            return Json(new {Data = Companylist});
        }
        #endregion

        #region Delete Company
        [HttpDelete]
        public IActionResult DeleteCompany(int id)
        {
            CompanyModel CompanyToBeDelelted = CompanyUnitOfWork.Company.Get(u => u.CompanyID == id);
            if(CompanyToBeDelelted == null)
            {
                return Json( new  { sucess = false,message="Error While Deleting" } );
            }
           
                CompanyUnitOfWork.Company.Remove(CompanyToBeDelelted);
                CompanyUnitOfWork.Save();
                return Json(new { sucess = true, message = "Delete Sucessfully" });
                
            }
        }
        #endregion
    }

