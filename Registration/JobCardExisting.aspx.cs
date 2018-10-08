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
                con.Open();
                //get Customer ID with the help of Customer Email
                string email = DropDownListSelectCustomerEmail.SelectedValue.ToString();
                Int32 CustomerID = QueryOperationsGet.CustomerTableOperations.GetCustomerIDByEmail(email);

                //get Vehicle ID by Vehicle Number
                Int32 getVehicleIDbyVehicleNo = QueryOperationsGet.VehicleTableOperations.GetVehicleIDByVehicleNumber(TextBoxVehicleNumber.Text);
                if (getVehicleIDbyVehicleNo == 0)
                {
                    //insert values in Vehicle Table
                    MySqlCommand cmd = new MySqlCommand("insert into vehicledetails (VehicleNo,VehicleBrand,VehicleModel,EngineNo,ChassisNo,CustUserID) values('" + TextBoxVehicleNumber.Text + "','" +
                                                        TextBoxVehicleBrand.Text + "','" + TextBoxVehicleModel.Text + "','" + TextBoxVehicleEngineNumber.Text + "','" + TextBoxVehicleChassisNumber.Text + "','" + CustomerID + "')", con);
                    cmd.ExecuteNonQuery();
                }
                //get Vehicle ID with the help of Customer ID
                Int32 getVehicleID = QueryOperationsGet.VehicleTableOperations.GetVehicleIDByCustomerIDAndVehicleNo(CustomerID,TextBoxVehicleNumber.Text);
                
                /*inserting values in job card details*/
                //get Employee ID with the help of Employee Email
                    Int32 getEmpID = QueryOperationsGet.EmployeeTableOperations.GetEmployeeIDByEmpEmail(Session["empname"].ToString());

                    string insertstring = "insert into jobcarddetails (VehicleProblem,ServiceStatus,CustUserID,VehicleID,EmpID) values('" + TextBoxVehicleProblem.Text + "','Pending','" + CustomerID + "','" + getVehicleID + "','" + getEmpID + "');";
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
            finally{con.Close();}
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