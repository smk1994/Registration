using System;
using MySql.Data.MySqlClient;
//Used To Fetch Countries List
using Registration.FetchCountries;
//To Encrypt Password and store in database
using Registration.PSecurity;

namespace Registration
{
    public partial class Register : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection("Server='localhost'; Database='aspcrud';User='root';Password='qwertyuiop12345';SslMode=None");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //used to call the method from FetchCountries
                DropDownListCountry.DataSource = Countries.country_name_list();
                DropDownListCountry.DataBind();
            }
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Function To Insert Values And Registration Details Of New Customer
            RegisterDetails();
        }

        //Function To Insert Values And Registration Details Of New Customer
        protected void RegisterDetails()
        {
            try
            {
                con.Open();
                string custemail = TextBoxEmail.Text;
                string checkexistingemail = "select CustEmail from registrationdetails where CustEmail like '" + custemail + "';";
                MySqlCommand cm = new MySqlCommand(checkexistingemail, con);

                if (cm.ExecuteScalar() == null)
                {
                    //inserting into registrationdetails table
                    string pass = PasswordEncrypt.EncryptText(TextBoxPassword.Text);
                    MySqlCommand cmd = new MySqlCommand("insert into registrationdetails (CustUserName,CustEmail,CustPassword,CustAddress,CustPhone,CustCountry) values('" + TextBoxUserName.Text + "','" +
                                                        custemail + "','" + pass + "','" + TextBoxAddress.Text + "','" + TextBoxPhone.Text + "','" + DropDownListCountry.Text + "')", con);
                    cmd.ExecuteNonQuery();
                    string getCustID = "select CustUserID from registrationdetails where CustEmail like '" + custemail + "';";
                    MySqlCommand cmd1 = new MySqlCommand(getCustID, con);
                    Int32 custID = (Int32)cmd1.ExecuteScalar();

                    //inserting into vehicledetails table
                    MySqlCommand cmd2 = new MySqlCommand("insert into vehicledetails (VehicleNo,VehicleBrand,VehicleModel,EngineNo,ChassisNo,CustUserID) values('" + TextBoxVehicleNumber.Text + "','" +
                                                            TextBoxVehicleBrand.Text + "','" + TextBoxVehicleModel.Text + "','" + TextBoxVehicleEngineNumber.Text + "','" + TextBoxVehicleChassisNumber.Text + "','" + custID + "')", con);
                    cmd2.ExecuteNonQuery();

                    //get vehicleID
                    string getVehicleID = "select VehicleID from vehicledetails where VehicleNo like '" + TextBoxVehicleNumber.Text +"';";
                    MySqlCommand cmd3 = new MySqlCommand(getVehicleID,con);
                    Int32 vehicleID = (Int32)cmd3.ExecuteScalar();

                    //get Employee ID
                    string getemployee = "select empid from employeedetails where empemail like '" + Session["empname"].ToString() + "';";
                    MySqlCommand cmd4 = new MySqlCommand(getemployee, con);
                    Int32 getEmpID = (Int32)cmd4.ExecuteScalar();

                    //inserting into jobcarddetails
                    MySqlCommand cmd5 = new MySqlCommand("insert into jobcarddetails (VehicleProblem,ServiceStatus,CustUserID,VehicleID,EmpID) values('" + TextBoxVehicleProblem.Text + "','Pending',"+ custID + ","+ vehicleID+","+ getEmpID+");",con);
                    cmd5.ExecuteNonQuery();

                    Label1.Visible = true;
                    Label1.Text = "Registration Successfull";
                    resetValues();
                }
                else
                {
                    Label1.Visible = true;
                    Label1.Text = "Cannot Register As Customer Already Exists! Please Choose Existing Customer!!";
                    resetValues();
                }
            }
            catch(Exception e)
            {
                Response.Write(e.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private void resetValues()
        {
            TextBoxUserName.Text = "";
            TextBoxEmail.Text = "";
            TextBoxRepeatPassword.Text = "";
            TextBoxPassword.Text = "";
            DropDownListCountry.Text = "Select Country";
            TextBoxVehicleNumber.Text = "";
            TextBoxVehicleBrand.Text = "";
            TextBoxVehicleModel.Text = "";
            TextBoxVehicleEngineNumber.Text = "";
            TextBoxVehicleChassisNumber.Text = "";
            TextBoxVehicleProblem.Text = "";
        }

        //Back Button
        protected void EmpButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeHomePage.aspx");
        }
    }
}