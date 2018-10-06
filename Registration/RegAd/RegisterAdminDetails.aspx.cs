using MySql.Data.MySqlClient;
using Registration.PSecurity;
using System;

namespace Registration.RegAd
{
    public partial class RegisterAdminDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                
        }
        private void Register()
        {
            MySqlConnection con = new MySqlConnection("Server='localhost'; Database='aspcrud';User='root';Password='qwertyuiop12345';SslMode=None");
            con.Open();

            string AdminUserName = "Sourabh Karmarkar";
            string AdminEmail = PasswordEncrypt.EncryptText("sourabh@gmail.com");
            string AdminPassword = PasswordEncrypt.EncryptText("Sourabh123!");
            MySqlCommand cmd = new MySqlCommand("insert into admin (adminname,adminemail,adminpassword) values('" + AdminUserName + "','" +
                                                AdminEmail + "','" + AdminPassword + "')", con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                SuccessRegister.Visible = true;
                SuccessRegister.Text = "Registration Successfull";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Register();
        }
    }
}