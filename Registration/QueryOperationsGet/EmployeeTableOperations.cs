using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Registration.QueryOperationsGet
{
    public class EmployeeTableOperations
    {
        public static Int32 GetEmployeeIDByEmpEmail(string EmpEmail)
        {
            MySqlConnection con = new MySqlConnection("Server='localhost'; Database='aspcrud';User='root';Password='qwertyuiop12345';SslMode=None");
            try
            {
                con.Open();
                string getemployee = "select empid from employeedetails where empemail like '" +EmpEmail+"';";
                MySqlCommand cmd1 = new MySqlCommand(getemployee, con);
                return (Int32)cmd1.ExecuteScalar();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return (Int32)0;
            }
            finally { con.Close(); }
        }
    }
}