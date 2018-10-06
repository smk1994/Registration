using MySql.Data.MySqlClient;
using Registration.PSecurity;
using System;

namespace Registration.LoginAccess
{
    public class GetLoginFlag
    {
        public int getLoginFlag(string TextBoxUsername,string TextBoxPassword)
        {
            using (MySqlConnection con = new MySqlConnection("Server='localhost'; Database='aspcrud';User='root';Password='qwertyuiop12345';SslMode=None"))
            {
                string query = "select count(1) from registrationdetails where CustEmail=@username and CustPassword=@password";
                string adminquery = "select count(1) from admin where adminemail=@admineml and adminpassword=@adminpass";
                string empquery = "select count(1) from employeedetails where empemail=@empeml and emppassword=@emppass";
                con.Open();
                //Customer
                MySqlCommand sqlCmd = new MySqlCommand(query, con);
                //Admin
                MySqlCommand adminsqlcmd = new MySqlCommand(adminquery, con);
                //Employee
                MySqlCommand empcmd = new MySqlCommand(empquery, con);
                string pass = PasswordEncrypt.EncryptText(TextBoxPassword);
                //Customer
                sqlCmd.Parameters.AddWithValue("@username", TextBoxUsername.Trim());
                sqlCmd.Parameters.AddWithValue("@password", pass.Trim());
                //Admin
                string adminuser = PasswordEncrypt.EncryptText(TextBoxUsername);
                adminsqlcmd.Parameters.AddWithValue("@admineml", adminuser.Trim());
                adminsqlcmd.Parameters.AddWithValue("@adminpass", pass.Trim());
                //Employee
                empcmd.Parameters.AddWithValue("@empeml", TextBoxUsername.Trim());
                empcmd.Parameters.AddWithValue("@emppass", pass.Trim());
                //Customer
                var count = sqlCmd.ExecuteScalar();
                //Admin
                var adminlogcnt = adminsqlcmd.ExecuteScalar();
                //Employee
                var empcount = empcmd.ExecuteScalar();

                if (Convert.ToInt32(adminlogcnt) == 1)
                {
                    return 2;
                }
                else
                if (Convert.ToInt32(empcount) == 1)
                {
                    return 3;
                }
                else
                if (Convert.ToInt32(count) == 1)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}