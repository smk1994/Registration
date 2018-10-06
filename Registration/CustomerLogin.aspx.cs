using System;
using Registration.LoginAccess;

namespace Registration
{
    public partial class CustomerLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelErrorMessage.Visible = false;
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
    }
}