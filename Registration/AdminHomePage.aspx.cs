using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI.WebControls;

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
        static bool flag = false;
        static int i = 0;
        protected void generate_radio_button(object sender, EventArgs e)
        {
            i++;
            Console.WriteLine("Start"+i);
            RadioButtonList1.Visible = true;
            ListItem item;
            item = new ListItem("Vehicle", "b1");
            RadioButtonList1.Items.Add(item);
            item = new ListItem("Customer", "b2");
            RadioButtonList1.Items.Add(item);
            flag = true;
            Console.WriteLine("End" + i);
        }
        protected void ButtonViewJobCard_Click(object sender, EventArgs e)
        {
            try
            {
                if (flag == false)
                {
                    generate_radio_button(sender, e);
                }
                else
                {
                    i++;
                    Console.WriteLine("ElseStart" + i);
                    flag = false;
                    RadioButtonList1.Items.RemoveAt(1);
                    RadioButtonList1.Items.RemoveAt(0);
                    RadioButtonList1.Items.Remove("Customer");
                    RadioButtonList1.Visible = false;
                    Console.WriteLine("ElseEnd" + i);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(),false);
            }
            /*
            RadioButton rb2 = new RadioButton();
            rb2.ID = "RadioButtonSearchByCustomer";
            rb2.Text = "Customer";
            Controls.Add(rb2);           
            */

            /*con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from registrationdetails",con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns.Remove("CustPassword");
            cmd.ExecuteNonQuery();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            con.Close();
            */
        }

        private void ShowServiceDetail(object sender, EventArgs e)
        {
            
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}