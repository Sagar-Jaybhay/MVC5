using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class DataAccess
    {
       
        private string _ConnectionString { get ;set; }


        public DataAccess()
        {
            this._ConnectionString= ConfigurationManager.ConnectionStrings["SQLServerConnection"].ConnectionString;
        }

        public DataTable GetTable(string Query)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using(var con=new SqlConnection(this._ConnectionString))
                {
                    con.Open();
                    var cmd = new SqlCommand(Query, con);
                    var adp = new SqlDataAdapter(cmd);
                    adp.Fill(dataTable);
                    cmd.Dispose();
                    adp.Dispose();
                    return dataTable;
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return null;
        }

        public void ExecuteProcedure(string Name,string Email,string Gender,double salary,int deptid,string city)
        {
            using(var con=new SqlConnection(this._ConnectionString))
            {
                con.Open();
                var cmd = new SqlCommand("spCreateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("name", SqlDbType.NVarChar, 20));
                cmd.Parameters.Add(new SqlParameter("salary", SqlDbType.Float, 50));
                cmd.Parameters.Add(new SqlParameter("gender", SqlDbType.NVarChar, 50));
                cmd.Parameters.Add(new SqlParameter("city", SqlDbType.NVarChar, 50));
                cmd.Parameters.Add(new SqlParameter("email", SqlDbType.NVarChar, 50));
                cmd.Parameters.Add(new SqlParameter("deptid", SqlDbType.Int, 50));

                cmd.Parameters["name"].Value = Name;
                cmd.Parameters["salary"].Value = salary;
                cmd.Parameters["gender"].Value = Gender;
                cmd.Parameters["city"].Value = city;
                cmd.Parameters["email"].Value = Email;
                cmd.Parameters["deptid"].Value = deptid;
                cmd.ExecuteNonQuery();
            }             

        }

        public void UpdateEmployee(int EmpId,string Name, string Email, string Gender, double salary, int deptid, string city)
        {
            using (var con = new SqlConnection(this._ConnectionString))
            {
                con.Open();
                var cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("name", SqlDbType.NVarChar, 20));
                cmd.Parameters.Add(new SqlParameter("salary", SqlDbType.Float, 50));
                cmd.Parameters.Add(new SqlParameter("gender", SqlDbType.NVarChar, 50));
                cmd.Parameters.Add(new SqlParameter("city", SqlDbType.NVarChar, 50));
                cmd.Parameters.Add(new SqlParameter("email", SqlDbType.NVarChar, 50));
                cmd.Parameters.Add(new SqlParameter("deptid", SqlDbType.Int, 50));
                cmd.Parameters.Add(new SqlParameter("emptid", SqlDbType.Int, 50));


                cmd.Parameters["name"].Value = Name;
                cmd.Parameters["salary"].Value = salary;
                cmd.Parameters["gender"].Value = Gender;
                cmd.Parameters["city"].Value = city;
                cmd.Parameters["email"].Value = Email;
                cmd.Parameters["deptid"].Value = deptid;
                cmd.Parameters["emptid"].Value = EmpId;

                cmd.ExecuteNonQuery();
            }

        }

    }
}
