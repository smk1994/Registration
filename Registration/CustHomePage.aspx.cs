using System;

namespace Registration
{
    public partial class CustHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("CustomerLogin.aspx");
            LabelUserDetails.Text = "Username : " + Session["username"];
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("CustomerLogin.aspx");
        }
    }
}