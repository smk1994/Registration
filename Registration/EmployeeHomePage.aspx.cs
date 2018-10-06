using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Registration
{
    public partial class EmployeeHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["empname"] == null)
                Response.Redirect("CustomerLogin.aspx");
            LabelEmpDetails.Text = "Username : " + Session["empname"];
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("CustomerLogin.aspx");
        }

        protected void btnEmpRegister(object sender,EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}