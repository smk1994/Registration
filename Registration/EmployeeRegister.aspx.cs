using MySql.Data.MySqlClient;
using Registration.PSecurity;
using System;
using System.Web.UI.WebControls;

namespace Registration
{
    public partial class EmployeeRegister : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection("Server='localhost'; Database='aspcrud';User='root';Password='qwertyuiop12345';SslMode=None");
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void EmpButton1_Click(object sender, EventArgs e)
        {
            //Function To Insert Values And Registration Details Of New Employee
            RegisterEmpDetails();
        }
        protected void RegisterEmpDetails()
        {
            con.Open();
            string emppass = PasswordEncrypt.EncryptText(TextBoxEmpPassword.Text);
            MySqlCommand cmd = new MySqlCommand("insert into employeedetails (empname,empemail,emppassword,empaddress,empphone) values('"+ TextBoxEmpUserName.Text+ "','" + TextBoxEmpEmail.Text + "','" +
                                                emppass + "','" + TextBoxEmpAddress.Text+ "'," + TextBoxEmpPhone.Text + ")", con);
            cmd.ExecuteNonQuery();
            con.Close();
            EmpRegisterLabel.Visible = true;
            EmpRegisterLabel.Text = "Registration Successfull";
            TextBoxEmpUserName.Text = "";
            TextBoxEmpEmail.Text = "";
            TextBoxEmpPassword.Text = "";
            TextBoxEmpAddress.Text = "";
            TextBoxEmpPhone.Text = "";
        }
    }
}