using MySql.Data.MySqlClient;
using System;

namespace Registration.QueryOperationsGet
{
    public class VehicleTableOperations
    {
        public static Int32 GetVehicleIDByCustomerIDAndVehicleNo(Int32 CustomerID,string VehicleNumber)
        {
            MySqlConnection con = new MySqlConnection("Server='localhost'; Database='aspcrud';User='root';Password='qwertyuiop12345';SslMode=None");
            try
            {
                con.Open();
                string getVehicleID = "select VehicleID from vehicledetails where CustUserID = " + CustomerID + " and VehicleNo like '"+VehicleNumber+"';";
                MySqlCommand cmd1 = new MySqlCommand(getVehicleID, con);
                return (Int32)cmd1.ExecuteScalar();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return (Int32)0;
            }
            finally { con.Close(); }
        }

        public static Int32 GetVehicleIDByVehicleNumber(string VehicleNo)
        {
            MySqlConnection con = new MySqlConnection("Server='localhost'; Database='aspcrud';User='root';Password='qwertyuiop12345';SslMode=None");
            try
            {
                con.Open();
                string getVehicleID = "select VehicleID from vehicledetails where VehicleNo like '" + VehicleNo + "';";
                MySqlCommand cmd1 = new MySqlCommand(getVehicleID, con);
                Object result = cmd1.ExecuteScalar();
                if (result == null)
                { return 0; }
                else
                { return (Int32)result; }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return (Int32)0;
            }
            finally { con.Close(); }
        }
    }
}

