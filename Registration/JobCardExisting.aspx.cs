using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Registration
{
    public partial class JobCardExisting : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection("Server='localhost'; Database='aspcrud';User='root';Password='qwertyuiop12345';SslMode=None");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                BindCustomerList(sender,e);
        }

        protected void BindCustomerList(object sender, EventArgs e)
        {
            DataTable dtemail = new DataTable();
            try
            {
                string sqlemail = "select CustEmail from registrationdetails";
                MySqlDataAdapter daemail = new MySqlDataAdapter(sqlemail, con);
                daemail.Fill(dtemail);
                if (dtemail.Rows.Count > 0)
                {
                    DropDownListSelectCustomerEmail.DataSource = dtemail;
                    DropDownListSelectCustomerEmail.DataTextField = "CustEmail"; // the items to be displayed in the list items
                    DropDownListSelectCustomerEmail.DataBind();
                    DropDownListSelectCustomerEmail.SelectedValue = "select email";
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Fetch Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                con.Close();
            }
        }

        protected void RegisterJobCard_Click(object sender, EventArgs e)
        {
            try
            {
                //get Customer ID with the help of Customer Email
                con.Open();
                string email = DropDownListSelectCustomerEmail.SelectedValue.ToString();
                string getID = "select CustUserID from registrationdetails where CustEmail like '" + email + "';";
                MySqlCommand cmd1 = new MySqlCommand(getID, con);
                Int32 getCustID = (Int32)cmd1.ExecuteScalar();

                
                //insert values in Vehicle Table
                MySqlCommand cmd = new MySqlCommand("insert into vehicledetails (VehicleNo,VehicleBrand,VehicleModel,EngineNo,ChassisNo,CustUserID) values('" + TextBoxVehicleNumber.Text + "','" +
                                                    TextBoxVehicleBrand.Text + "','" + TextBoxVehicleModel.Text + "','" + TextBoxVehicleEngineNumber.Text + "','" + TextBoxVehicleChassisNumber.Text + "','" + getCustID + "')", con);
                cmd.ExecuteNonQuery();

                //inserting values in job card details
                string getvehicle = "select VehicleID from vehicledetails where CustUserID = " +getCustID+ ";";
                MySqlCommand cmd3 = new MySqlCommand(getvehicle,con);
                Int32 getVehicleID= (Int32)cmd3.ExecuteScalar();
                string getemployee= "select empid from employeedetails where empemail like '" + Session["empname"].ToString() + "';";
                MySqlCommand cmd4 = new MySqlCommand(getemployee, con);
                Int32 getEmpID = (Int32)cmd4.ExecuteScalar();

                string insertstring = "insert into jobcarddetails (VehicleProblem,ServiceStatus,CustUserID,VehicleID,EmpID) values('" + TextBoxVehicleProblem.Text + "','Pending','" + getCustID + "','" + getVehicleID + "','" + getEmpID + "');";
                MySqlCommand cmd2 = new MySqlCommand(insertstring, con);
                cmd2.ExecuteNonQuery();
                
                JobCardLabel.Visible = true;
                JobCardLabel.Text = "Job Card Generated Successfully";
                resetValues();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Job Card Cannot Be Generated");
                JobCardLabel.Visible = true;
                JobCardLabel.Text = "Job Card Cannot Be Generated";
            }
            finally
            {
                con.Close();
            }
        }

        private void resetValues()
        {
            TextBoxVehicleNumber.Text = "";
            TextBoxVehicleBrand.Text = "";
            TextBoxVehicleModel.Text = "";
            TextBoxVehicleEngineNumber.Text = "";
            TextBoxVehicleChassisNumber.Text = "";
            TextBoxVehicleProblem.Text = "";
        }
    }
}