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
            TryUpdateModel(employee,null,null,new string[]{"EmpID" });
            ModelState.Remove("EmpID");

            if (ModelState.IsValid)
            {
                new BusinessLogic.Business().CreateEmployee(employee);
                return RedirectToAction("DisplayCompleteEmployee");
            }else
            {
                //if (!ModelState.IsValid)
              
                    var modelErrors = new List<string>();
                    foreach (var modelState in ModelState.Values)
                    {
                        foreach (var modelError in modelState.Errors)
                        {
                            modelErrors.Add(modelError.ErrorMessage);
                        }
                    }
                    // do something with the error list :)
                
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(string EmpID)
        {
            var Employye = new BusinessLogic.Business().GetEmployee(EmpID);

            return View(Employye);

        }

        [HttpPost] // Include Or Exclude Properties Using UpdateModel function
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

        //[HttpPost] // Bind Atrtibute Function
        //public ActionResult Edit([Bind(Exclude ="EmpName")]Employee employee)
        ////public ActionResult Edit([Bind(Include = "EmpID,EmpGender,EmpSalary, EmpCity, EmpEmail, DepartmentID")]Employee employee)
        //{
        //    var emp = new BusinessLogic.Business().GetEmployee(employee.EmpID.ToString());
        //    employee.EmpName = emp.EmpName;


        //  //  UpdateModel(emp, new string[] { "EmpSalary", "EmpGender", "EmpCity", "EmpEmail", "DepartmentID" });
        //    if (ModelState.IsValid)
        //    {
        //        new BusinessLogic.Business().UpdateEmployee(employee);
        //        return RedirectToAction("DisplayCompleteEmployee");
        //    }
        //    return View(employee);

        //}


        //[HttpPost] // Bind Atrtibute Function
        //public ActionResult Edit(int EmpID)       
        //{
        //    var emp = new BusinessLogic.Business().GetEmployee(EmpID.ToString());
        //    UpdateModel<Iemployee>(emp);            
        //    if (ModelState.IsValid)
        //    {
        //        new BusinessLogic.Business().UpdateEmployee(emp);
        //        return RedirectToAction("DisplayCompleteEmployee");
        //    }
        //    return View(emp);

        //}

        [HttpPost]
        public ActionResult Delete(string EmpID)
        {
            new BusinessLogic.Business().DeleteEmployee(Convert.ToInt32(EmpID));            
            return RedirectToAction("DisplayCompleteEmployee");
        }

        public ActionResult wheretofindview()
        {
            return View("~/Views/Employee/wheretofindview.cshtml");

        }

    }
}