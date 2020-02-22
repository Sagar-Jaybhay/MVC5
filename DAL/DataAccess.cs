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





    }
}
