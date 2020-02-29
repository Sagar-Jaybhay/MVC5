using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Employee
    {
        [DisplayName("ID")]
        public int EmpID { get; set; }
        [Required]
        [DisplayName("Name")]
        public string EmpName { get; set; }
        [Required]
        [DisplayName("Salary")]
        public double EmpSalary { get; set; }
        [Required]
        [DisplayName("Gender")]
        public string EmpGender { get; set; }
        [DisplayName("City")]
        [Required]
        public string EmpCity { get; set; }
        [Required]
        [DisplayName("Email")]
        public string EmpEmail { get; set; }
        [Required]
        public int DepartmentID { get; set; }

    }
}