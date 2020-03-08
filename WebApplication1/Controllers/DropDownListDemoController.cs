using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class DropDownListDemoController : Controller
    {
        private BusinessLogic.Business business = null;
        public DropDownListDemoController()
        {
            this.business = new BusinessLogic.Business();

        }
        // GET: DropDownListDemo
        public ActionResult Index()
        {
            
            ViewBag.Departments =new SelectList(this.business.GetDepartments(), "DepartmentID", "DepartmentName");

            return View();
        }

        public ActionResult DefaultSelectedDrop()
        {
            List<SelectListItem> selectLists = new List<SelectListItem>();
            foreach(var items in this.business.GetDepartment())
            {
                var p = new SelectListItem()
                {
                    Text=items.DepartmentName,
                    Value=items.DepartmentID.ToString(),
                    Selected=(bool)items.isSelected
                        
                };
                selectLists.Add(p);
            }

            ViewBag.Departments = selectLists;
            return View();
        }

    }
}