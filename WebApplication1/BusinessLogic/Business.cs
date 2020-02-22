using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.BusinessLogic
{
    public class Business
    {
        private DataAccess dataAccess = null;
        public Business()
        {
            this.dataAccess = new DataAccess();

        }

        public Employee GetEmployee(string EmpId)
        {
            Employee employee;
            string Query = "select * from Employee where EmpID="+EmpId;
            var data = this.dataAccess.GetTable(Query);
            if(data!=null&&data.Rows.Count>0)
            {
                employee = new Employee()
                {
                    EmpID = Convert.ToInt32(data.Rows[0]["EmpID"]),
                    EmpCity = data.Rows[0]["EmpCity"].ToString(),
                    EmpEmail = data.Rows[0]["EmpEmail"].ToString(),
                    EmpGender = data.Rows[0]["EmpGender"].ToString(),
                    EmpName = data.Rows[0]["EmpName"].ToString(),
                    EmpSalary = Convert.ToDouble(data.Rows[0]["EmpSalary"].ToString())
                };

                return employee;
            }
            return null;

        }

        public List<int> GetEmpIDs()
        {
            List<int> ids = new List<int>();
            string Query = "select top 100 EmpID from Employee";
            var data=this.dataAccess.GetTable(Query);
            if(data!=null&&data.Rows.Count>0)
            {
                foreach (DataRow id in data.Rows)
                    ids.Add(Convert.ToInt32(id["EmpID"]));
            }
            return ids;
        }
    }
}