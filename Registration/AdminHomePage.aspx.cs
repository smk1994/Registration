using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Registration
{
    public partial class AdminHomePage : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection("Server='localhost'; Database='aspcrud';User='root';Password='qwertyuiop12345';SslMode=None");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminame"] == null)
                Response.Redirect("CustomerLogin.aspx");
            AdminEmail.Text = "Username : " + Session["adminame"];
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("CustomerLogin.aspx");
        }
                
        protected void ButtonViewDetails_Click(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from employeedetails", con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns.Remove("emppassword");
            cmd.ExecuteNonQuery();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            con.Close();
        }

        protected void ButtonCustomerViewDetails_Click(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from registrationdetails", con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns.Remove("CustPassword");
            cmd.ExecuteNonQuery();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            con.Close();
        }

        /*protected void ButtonViewJobCard_Click(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from registrationdetails",con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns.Remove("CustPassword");
            cmd.ExecuteNonQuery();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            con.Close();
        }
        */
    }
}