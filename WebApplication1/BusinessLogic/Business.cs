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
                    EmpSalary = Convert.ToDouble(data.Rows[0]["EmpSalary"].ToString()),
                    DepartmentID = Convert.ToInt32(data.Rows[0]["DepartmentID"].ToString())
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

        public List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();
            string query = "select * from Department order by DepartmentID";
            var data = this.dataAccess.GetTable(query);
            if(data!=null&&data.Rows.Count>0)
            {

                foreach(DataRow dataRow in data.Rows)
                {
                    var dept = new Department()
                    {
                        DepartmentID = Convert.ToInt32(dataRow["DepartmentID"].ToString()),
                        DepartmentName = dataRow["DepartmentName"].ToString()
                    };
                    departments.Add(dept);
                }

            }
            return departments;

        }
        public List<int> GetEmpIDs(string DepartmentID)
        {
            List<int> ids = new List<int>();
            string Query = "select  EmpID from Employee where DepartmentID="+DepartmentID;
            var data = this.dataAccess.GetTable(Query);
            if (data != null && data.Rows.Count > 0)
            {
                foreach (DataRow id in data.Rows)
                    ids.Add(Convert.ToInt32(id["EmpID"]));
            }
            return ids;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            string Query = "select top 25 * from Employee";
            var data = this.dataAccess.GetTable(Query);
            if(data!=null&&data.Rows.Count>0)
            {
                foreach(DataRow dataRow in data.Rows)
                {
                    var emp = new Employee()
                    {
                        EmpID = Convert.ToInt32(dataRow["EmpID"]),
                        EmpCity = dataRow["EmpCity"].ToString(),
                        EmpEmail = dataRow["EmpEmail"].ToString(),
                        EmpGender = dataRow["EmpGender"].ToString(),
                        EmpName = dataRow["EmpName"].ToString(),
                        EmpSalary = Convert.ToDouble(dataRow["EmpSalary"].ToString()),
                        DepartmentID = Convert.ToInt32(dataRow["DepartmentID"].ToString())


                    };
                    employees.Add(emp);

                }

            }
            return employees;


        }

    }
}