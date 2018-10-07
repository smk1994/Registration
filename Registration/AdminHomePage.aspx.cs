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

        //Function To Show Vehicle Details
        protected void ButtonViewDetails_Click(object sender, EventArgs e)
        {
            try
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
                GridView1.Visible = true;
                
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            finally {con.Close();vehiclelist.Visible = false;customerlist.Visible = false;RadioButtonList1.Visible = false;}
        }

        //Function To Show Customer Details
        protected void ButtonCustomerViewDetails_Click(object sender, EventArgs e)
        {
            try
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
                GridView1.Visible = true;
                con.Close();
            }
            catch (Exception ex){Console.WriteLine(ex.ToString());}
            finally { con.Close(); vehiclelist.Visible = false; customerlist.Visible = false; RadioButtonList1.Visible = false; }
        }
        static bool flag = false;
        static int i = 0;
        protected void generate_radio_button(object sender, EventArgs e)
        {
            try
            {
                i++;
                Console.WriteLine("Start" + i);
                RadioButtonList1.Visible = true;
                ListItem item;
                item = new ListItem("Vehicle", "b1");
                RadioButtonList1.Items.Add(item);
                item = new ListItem("Customer", "b2");
                RadioButtonList1.Items.Add(item);
                flag = true;
                Console.WriteLine("End" + i);
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }
        
        protected void ButtonViewJobCard_Click(object sender, EventArgs e)
        {
            try
            {
                GridView1.Visible = false;
                if (flag == false)
                    generate_radio_button(sender, e);
                else
                {
                    flag = false;
                    vehiclelist.Visible = false;
                    customerlist.Visible = false;
                    RadioButtonList1.Items.RemoveAt(1);
                    RadioButtonList1.Items.RemoveAt(0);
                    RadioButtonList1.Items.Remove("Customer");
                    RadioButtonList1.Visible = false;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }

        //Function called when radiobutton is selected
        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            GridView1.Visible = false;
            if (RadioButtonList1.SelectedIndex == 0)
            {
                //function call for fetching vehicle number to the dropdownlist
                customerlist.Visible = false;
                BindVehicleListDropDown(sender, e);
            }
            else
            if(RadioButtonList1.SelectedIndex == 1)
            {
                //function call for fetching customer list to the dropdownlist
                vehiclelist.Visible = false;
                BindCustomerListDropDown(sender, e);
            }
        }

        //function call for fetching customer list to the dropdownlist
        protected void BindCustomerListDropDown(object sender, EventArgs e)
        {
            DataTable dtemail = new DataTable();
            try
            {
                string sqlemail = "select CustEmail from registrationdetails";
                MySqlDataAdapter daemail = new MySqlDataAdapter(sqlemail, con);
                daemail.Fill(dtemail);
                if (dtemail.Rows.Count > 0)
                {
                    customerlist.DataSource = dtemail;
                    customerlist.DataTextField = "CustEmail"; // the items to be displayed in the list items
                    customerlist.DataBind();
                }
                customerlist.Visible = true;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Fetch Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            { con.Close(); }
        }

        //function for fetching vehicle number to the dropdownlist
        protected void BindVehicleListDropDown(object sender, EventArgs e)
        {
            DataTable dtemail = new DataTable();
            try
            {
                string sqlemail = "select VehicleNo from vehicledetails";
                MySqlDataAdapter daemail = new MySqlDataAdapter(sqlemail, con);
                daemail.Fill(dtemail);
                if (dtemail.Rows.Count > 0)
                {
                    vehiclelist.DataSource = dtemail;
                    vehiclelist.DataTextField = "VehicleNo"; // the items to be displayed in the list items
                    vehiclelist.DataBind();
                }
                vehiclelist.Visible = true;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Fetch Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {con.Close();}
        }

        //Display Service Details Vehicle Number Wise
        protected void vehiclelist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string vehicleno = vehiclelist.SelectedValue.ToString();
                //get vehicle ID based on Vehicle Number
                string getVehicleID = "select VehicleID from vehicledetails where VehicleNo like '" + vehicleno + "';";
                MySqlCommand cmd3 = new MySqlCommand(getVehicleID, con);
                Int32 vehicleid = (Int32)cmd3.ExecuteScalar();
                string getalldetails = "select registrationdetails.CustUserName as Customer_Name,registrationdetails.CustEmail as Email,registrationdetails.CustAddress as Address,vehicledetails.VehicleNo as Vehicle_No,vehicledetails.VehicleBrand,vehicledetails.VehicleModel,vehicledetails.ChassisNo,vehicledetails.EngineNo,jobcarddetails.VehicleProblem,jobcarddetails.ServiceStatus,employeedetails.empname as Employee_Name,employeedetails.empemail as Employee_Email from registrationdetails,vehicledetails,jobcarddetails,employeedetails where registrationdetails.CustUserID=jobcarddetails.CustUserID and vehicledetails.VehicleID=jobcarddetails.VehicleID and employeedetails.empid=jobcarddetails.EmpID and jobcarddetails.VehicleID=" + vehicleid;
                MySqlCommand cmd = new MySqlCommand(getalldetails, con);
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

        protected void customerlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string CustomerEmail = customerlist.SelectedValue.ToString();
                //get vehicle ID based on Vehicle Number
                string getCustomerID = "select CustUserID from registrationdetails where CustEmail like '" + CustomerEmail + "';";
                MySqlCommand cmd3 = new MySqlCommand(getCustomerID, con);
                Int32 CustomerID = (Int32)cmd3.ExecuteScalar();
                string getalldetails = "select registrationdetails.CustUserName as Customer_Name,registrationdetails.CustEmail as Email,registrationdetails.CustAddress as Address,vehicledetails.VehicleNo as Vehicle_No,vehicledetails.VehicleBrand,vehicledetails.VehicleModel,vehicledetails.ChassisNo,vehicledetails.EngineNo,jobcarddetails.VehicleProblem,jobcarddetails.ServiceStatus,employeedetails.empname as Employee_Name,employeedetails.empemail as Employee_Email from registrationdetails,vehicledetails,jobcarddetails,employeedetails where registrationdetails.CustUserID=jobcarddetails.CustUserID and vehicledetails.VehicleID=jobcarddetails.VehicleID and employeedetails.empid=jobcarddetails.EmpID and jobcarddetails.CustUserID=" + CustomerID;
                MySqlCommand cmd = new MySqlCommand(getalldetails, con);
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