using MySql.Data.MySqlClient;
using System;
using System.Data;

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
        static int flag = 0;

        //called when ServiceHistoryButton Button is clicked
        protected void createVehicleListDropDown(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                PopulateVehicleListDropDown(sender, e);
                flag = 1;
            }
            else
            {
                SelectVehicle.Visible = false;
                GridView1.Visible = false;
                flag = 0;
            }
        }

        private void PopulateVehicleListDropDown(object sender, EventArgs e)
        {
            DataTable dtemail = new DataTable();
            MySqlConnection con = new MySqlConnection("Server='localhost'; Database='aspcrud';User='root';Password='qwertyuiop12345';SslMode=None");
            try
            { 
                Int32 CustomerID = QueryOperationsGet.CustomerTableOperations.GetCustomerIDByEmail(Session["username"].ToString());
                string sqlemail = "select VehicleNo from vehicledetails where CustuserID="+CustomerID;
                MySqlDataAdapter daemail = new MySqlDataAdapter(sqlemail, con);
                daemail.Fill(dtemail);
                if (dtemail.Rows.Count > 0)
                {
                    SelectVehicle.DataSource = dtemail;
                    SelectVehicle.DataTextField = "VehicleNo"; // the items to be displayed in the list items
                    SelectVehicle.DataBind();
                    SelectVehicle.Visible = true;
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Fetch Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally{con.Close();}
        }

        protected void showServiceHistory(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Server='localhost'; Database='aspcrud';User='root';Password='qwertyuiop12345';SslMode=None");
            try
            {
                con.Open();
                Int32 CustomerID = QueryOperationsGet.CustomerTableOperations.GetCustomerIDByEmail(Session["username"].ToString());
                string showservicedetails = "select vehicledetails.VehicleNo,vehicledetails.VehicleBrand,vehicledetails.VehicleModel,jobcarddetails.VehicleProblem,jobcarddetails.ServiceStatus,employeedetails.empemail as Serviced_By from vehicledetails,employeedetails,jobcarddetails where jobcarddetails.EmpID=employeedetails.empid and vehicledetails.VehicleID=jobcarddetails.VehicleID and jobcarddetails.CustUserID=" + CustomerID + " and vehicledetails.VehicleNo like'"+SelectVehicle.SelectedValue+"';";
                MySqlCommand cmd = new MySqlCommand(showservicedetails, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmd.ExecuteNonQuery();
                GridView1.DataSource = dt;
                GridView1.DataBind();
                GridView1.Visible = true;
                con.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            finally { con.Close(); }
        }
    }
}