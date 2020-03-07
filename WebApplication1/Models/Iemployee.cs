using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    interface Iemployee
    {      
       int EmpID { get; set; }          
       double EmpSalary { get; set; }       
       string EmpGender { get; set; }       
       string EmpCity { get; set; }       
       string EmpEmail { get; set; }  
   
    }
}
