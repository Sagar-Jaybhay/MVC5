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
        public ActionResult DisplayDepartments()
        {
            var data = new BusinessLogic.Business().GetDepartments();
            return View(data);
        }
        public ActionResult EmployeeList(string DEptID)
        {
            var data = new BusinessLogic.Business().GetEmpIDs(DEptID);
            ViewBag.EmpIDs = data;
            return View();
        }

        public ActionResult DisplayCompleteEmployee()
        {
            var emplist = new BusinessLogic.Business().GetEmployees();

            return View(emplist);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Create(Employee employee)
        //{
        //    new BusinessLogic.Business().CreateEmployee(employee);
        //    return RedirectToAction("DisplayCompleteEmployee");
        //}

        //[HttpPost]
        //public ActionResult Create(string EmpName, string EmpSalary, string gender,string EmpEmail, string EmpCity, int departmentid )
        //{
        //    var employee = new Employee()
        //    {
        //        EmpName= EmpName,
        //        EmpSalary=Convert.ToDouble(EmpSalary),
        //        EmpCity= EmpCity,
        //        EmpEmail= EmpEmail,
        //        EmpGender=gender,
        //        DepartmentID=departmentid


        //    };

        //    new BusinessLogic.Business().CreateEmployee(employee);
        //    return RedirectToAction("DisplayCompleteEmployee");
        //}

        //[HttpPost] // using UpdateModel
        //[ActionName("Create")]
        //public ActionResult Create_Post()
        //{
        //    Employee employee = new Employee();

        //    if (ModelState.IsValid)
        //    {
        //        UpdateModel(employee);

        //        new BusinessLogic.Business().CreateEmployee(employee);
        //        return RedirectToAction("DisplayCompleteEmployee");
        //    }
        //    return View();
        //}
        [HttpPost] // using TryUpdateModel
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            Employee employee = new Employee();
            TryUpdateModel(employee);

            if (ModelState.IsValid)
            {
                new BusinessLogic.Business().CreateEmployee(employee);
                return RedirectToAction("DisplayCompleteEmployee");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(string EmpID)
        {
            var Employye = new BusinessLogic.Business().GetEmployee(EmpID);

            return View(Employye);

        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            var emp = new BusinessLogic.Business().GetEmployee(employee.EmpID.ToString());



            UpdateModel(emp, new string[] { "EmpSalary", "EmpGender", "EmpCity", "EmpEmail", "DepartmentID" });
            if (ModelState.IsValid)
            {
                new BusinessLogic.Business().UpdateEmployee(emp);
                return RedirectToAction("DisplayCompleteEmployee");
            }
            return View(employee);

        }

    }
}