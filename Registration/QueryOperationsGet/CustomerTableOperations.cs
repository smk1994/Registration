using MySql.Data.MySqlClient;
using System;

namespace Registration.QueryOperationsGet
{
    public class CustomerTableOperations
    {
        public static Int32 GetCustomerIDByEmail(string email)
        {
            MySqlConnection con = new MySqlConnection("Server='localhost'; Database='aspcrud';User='root';Password='qwertyuiop12345';SslMode=None");
            try
            {
                con.Open();
                string getCustomerID = "select CustUserID from registrationdetails where CustEmail like '" + email + "';";
                MySqlCommand cmd1 = new MySqlCommand(getCustomerID, con);
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