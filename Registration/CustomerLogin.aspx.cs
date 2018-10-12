using System;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Registration.LoginAccess;

namespace Registration
{
    public partial class CustomerLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelErrorMessage.Visible = false;
            forgotpasswordtextbox.Visible = true;
            ForgotPasswordButton.Visible = true;
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            //Function To Validate Login
            GetLoginFlag g = new GetLoginFlag();
            int flag=g.getLoginFlag(TextBoxUsername.Text, TextBoxPassword.Text);

            if (flag == 1)
            {
                Session["username"] = TextBoxUsername.Text.Trim();
                Response.Redirect("CustHomePage.aspx");
            }
            else
            if (flag == 2)
            {
                Session["adminame"] = TextBoxUsername.Text.Trim();
                Response.Redirect("AdminHomePage.aspx");
            }
            else
            if(flag == 3)
            {
                Session["empname"] = TextBoxUsername.Text.Trim();
                Response.Redirect("EmployeeHomePage.aspx");
            }
            else
            {
                LabelErrorMessage.Visible = true;
                TextBoxUsername.Text = "";
                TextBoxPassword.Text = "";
            }
        }

        //function to add textbox for email and button to send email on CustomerLogin.aspx
        protected void ForgotPasswordMethod(object sender, EventArgs e)
        {
            try
            {
                forgotpasswordtextbox.Visible = true;
                ForgotPasswordButton.Visible = true;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }

        protected void ForgotPasswordMethodSendEmail(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }
        /* //function to send forgot password link to the registered email
         protected void sendForgotPasswordEmail(Object sender, EventArgs e)
         {
             MySqlConnection con = new MySqlConnection("Server='localhost'; Database='aspcrud';User='root';Password='qwertyuiop12345';SslMode=None");
             try
             {
                 con.Open();
                 string getEmailFromDB = "select CustEmail from registrationdetails where CustEmail like '" + txt.Text + "';";
                 MySqlCommand cmd = new MySqlCommand(getEmailFromDB,con);
                 string fetchedEmail=cmd.ExecuteScalar().ToString();
                 Console.WriteLine(fetchedEmail);
             }
             catch (Exception ex) { ex.ToString(); }
             finally { con.Close(); }
         }*/
    }
}