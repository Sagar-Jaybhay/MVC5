using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Employee
    {

        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public double EmpSalary { get; set; }
        public string EmpGender { get; set; }
        public string EmpCity { get; set; }
        public string EmpEmail { get; set; }
        public int DepartmentID { get; set; }
    }
}