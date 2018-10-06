<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Registration.Register" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type= "text/javascript" src = "CountriesList/countries.js"></script>
    <title>Customer Registration</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            background-color:lightcyan;
        }
    </style>
</head>
<body style="text-align:center;background-color:wheat">
    <form id="form1" runat="server">
        <div>
            <h1>Enter Details</h1>
        </div>
        <br />
        <br />
            <table class="auto-style1" border="2">
                <tr>
                    <td>Name :</td>
                    <td>
                        <asp:TextBox ID="TextBoxUserName" runat="server" Width="100%"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUserName" ErrorMessage="User Name is required" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBoxUserName" Display="Dynamic" ErrorMessage="Username must contain letters Length between 5-15" ForeColor="#FF0066" ValidationExpression="[a-zA-Z ]{4,25}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Email :</td>
                    <td>
                        <asp:TextBox ID="TextBoxEmail" runat="server" Width="100%"></asp:TextBox>
                        <br />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="Email is required" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Email is Invalid" ForeColor="#FF0066" ControlToValidate="TextBoxEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Password :</td>
                    <td>
                        <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" Width="100%"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxPassword" ErrorMessage="Password is required" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBoxPassword" Display="Dynamic" ErrorMessage="Password Must Contain a lowercase and uppercase letter, number and any special character. Length betweeen 6-20" ForeColor="#FF0066" ValidationExpression="^((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%&]).{6,20})$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Confirm Password :</td>
                    <td>
                        <asp:TextBox ID="TextBoxRepeatPassword" runat="server" TextMode="Password" Width="100%"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxRepeatPassword" ErrorMessage="Confirm Password is required" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBoxPassword" ControlToValidate="TextBoxRepeatPassword" ErrorMessage="Passwords Must Match" ForeColor="#FF0066"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>Address :</td>
                    <td>
                        <asp:TextBox ID="TextBoxAddress" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" runat="server" ControlToValidate="TextBoxAddress" ErrorMessage="Address Is Required" ForeColor="#FF0066" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Phone Number :</td>
                    <td>
                        <asp:TextBox ID="TextBoxPhone" runat="server" TextMode="Number" Width="100%"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxPhone" Display="Dynamic" ErrorMessage="Phone Number Is Required" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxPhone" Display="Dynamic" ErrorMessage="Invalid Phone Number" ForeColor="#FF0066" ValidationExpression="^[0-9]{5,10}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Country :</td>
                    <td>
                        <asp:DropDownList ID="DropDownListCountry" runat="server" Height="31px" Width="238px">
                            <asp:ListItem>Select Country</asp:ListItem>
                            <asp:ListItem>US</asp:ListItem>
                            <asp:ListItem>UK</asp:ListItem>
                            <asp:ListItem>Germany</asp:ListItem>
                            <asp:ListItem>France</asp:ListItem>
                            <asp:ListItem>India</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="DropDownListCountry" ErrorMessage="Select a Country Name" ForeColor="#FF0066" InitialValue="Select Country" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <!--Vehicle Details-->
                <tr>
                    <td>Vechicle Number :</td>
                    <td>
                        <asp:TextBox ID="TextBoxVehicleNumber" runat="server" Width="100%"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>Brand :</td>
                    <td>
                        <asp:TextBox ID="TextBoxVehicleBrand" runat="server" Width="100%"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>Model :</td>
                    <td>
                        <asp:TextBox ID="TextBoxVehicleModel" runat="server" Width="100%"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>Engine Number :</td>
                    <td>
                        <asp:TextBox ID="TextBoxVehicleEngineNumber" runat="server" Width="100%"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>Chassis Number :</td>
                    <td>
                        <asp:TextBox ID="TextBoxVehicleChassisNumber" runat="server" Width="100%"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>Vehicle Problems :</td>
                    <td>
                        <asp:TextBox ID="TextBoxVehicleProblem" runat="server" Width="100%"></asp:TextBox>
                    </td>
                    <td>
                    </td>
            </table>
            <p><asp:Button ID="Button1" runat="server" Text="Register Job Card" Width="12%" OnClick="Button1_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input id="Reset1" type="reset" value="Reset" /></p>
            <asp:Label ID="Label1" runat="server" ForeColor="#33CC33" Text=""></asp:Label>
        </form>
        <asp:HyperLink ID="hyperlinkBack" runat="server" BackColor="#00CC00" BorderColor="Black" BorderWidth="2px" ForeColor="Black" NavigateUrl="~/EmployeeHomePage.aspx">Back</asp:HyperLink>
        <asp:HyperLink ID="HyperLinkExistingCustomer" runat="server" ForeColor="#0033CC" NavigateUrl="~/JobCardExisting.aspx">Existing Customer</asp:HyperLink>
    </body>
</html>
<script type="javascript">
    populateCountries("DropDownListCountry");
</script>
