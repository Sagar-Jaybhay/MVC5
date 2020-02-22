using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index(string EmpID)
        {
            Employee employee = new BusinessLogic
                .Business().GetEmployee(EmpID);

            return View(employee);
        }

        public ActionResult GetEmpIDs()
        {
            var list = new BusinessLogic.Business().GetEmpIDs();
            ViewData["ids"] = list;
            return View();

        }
    }
}