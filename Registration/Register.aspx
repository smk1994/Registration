<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Registration.Register" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type= "text/javascript" src = "CountriesList/countries.js"></script>
    <title>Customer Registration</title>
    <style>
        body {
            background-color:wheat;
        }
        td{
            
        }
        td.col1 {
            text-align:right;
        }
        .col2 {
            width: 704px;
        }
        .auto-style1 {
            height: 30px;
        }
        .auto-style2 {
            width: 704px;
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width:90%;height:50%;align-self:center">
            <table aria-checked="true" style="width: 100%; height: 100%">
                <tr>
                    <td class="col1">Name :</td>
                    <td>
                        <asp:TextBox ID="TextBoxUserName" runat="server" Width="100%"></asp:TextBox>
                    </td>
                    <td class="col2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUserName" ErrorMessage="User Name is required" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBoxUserName" Display="Dynamic" ErrorMessage="Username must contain letters Length between 5-15" ForeColor="#FF0066" ValidationExpression="[a-zA-Z ]{4,25}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="col1">Email :</td>
                    <td>
                        <asp:TextBox ID="TextBoxEmail" runat="server" Width="100%"></asp:TextBox>
                        <br />
                    </td>
                    <td class="col2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="Email is required" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Email is Invalid" ForeColor="#FF0066" ControlToValidate="TextBoxEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="col1">Password :</td>
                    <td>
                        <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" Width="100%"></asp:TextBox>
                    </td>
                    <td class="col2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxPassword" ErrorMessage="Password is required" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBoxPassword" Display="Dynamic" ErrorMessage="Password Must Contain a lowercase and uppercase letter, number and any special character. Length betweeen 6-20" ForeColor="#FF0066" ValidationExpression="^((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%&]).{6,20})$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="col1">Confirm Password :</td>
                    <td>
                        <asp:TextBox ID="TextBoxRepeatPassword" runat="server" TextMode="Password" Width="100%"></asp:TextBox>
                    </td>
                    <td class="col2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxRepeatPassword" ErrorMessage="Confirm Password is required" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBoxPassword" ControlToValidate="TextBoxRepeatPassword" ErrorMessage="Passwords Must Match" ForeColor="#FF0066"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="col1">Address :</td>
                    <td>

                        <asp:TextBox ID="TextBoxAddress" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>

                    </td>
                    <td class="col2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" runat="server" ControlToValidate="TextBoxAddress" ErrorMessage="Address Is Required" ForeColor="#FF0066" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="col1">Phone Number :</td>
                    <td>
                        <asp:TextBox ID="TextBoxPhone" runat="server" TextMode="Number" Width="100%"></asp:TextBox>
                    </td>
                    <td class="col2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxPhone" Display="Dynamic" ErrorMessage="Phone Number Is Required" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxPhone" Display="Dynamic" ErrorMessage="Invalid Phone Number" ForeColor="#FF0066" ValidationExpression="^[0-9]{5,10}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="col1">Country :</td>
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
                    <td class="col2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="DropDownListCountry" ErrorMessage="Select a Country Name" ForeColor="#FF0066" InitialValue="Select Country" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <!--Vehicle Details-->
                <tr>
                    <td class="col1">Vechicle Number :</td>
                    <td>
                        <asp:TextBox ID="TextBoxVehicleNumber" runat="server" Width="100%"></asp:TextBox>
                    </td>
                    <td class="col2">
                    </td>
                </tr>
                <tr>
                    <td class="col1">Brand :</td>
                    <td>
                        <asp:TextBox ID="TextBoxVehicleBrand" runat="server" Width="100%"></asp:TextBox>
                    </td>
                    <td class="col2">
                    </td>
                </tr>
                <tr>
                    <td class="col1">Model :</td>
                    <td>
                        <asp:TextBox ID="TextBoxVehicleModel" runat="server" Width="100%"></asp:TextBox>
                    </td>
                    <td class="col2">
                    </td>
                </tr>
                <tr>
                    <td class="col1">Engine Number :</td>
                    <td>
                        <asp:TextBox ID="TextBoxVehicleEngineNumber" runat="server" Width="100%"></asp:TextBox>
                    </td>
                    <td class="col2">
                    </td>
                </tr>
                <tr>
                    <td class="col1">Chassis Number :</td>
                    <td>
                        <asp:TextBox ID="TextBoxVehicleChassisNumber" runat="server" Width="100%"></asp:TextBox>
                    </td>
                    <td class="col2">
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style1">
                        <asp:Button ID="Button1" runat="server" Text="Register" Width="104px" OnClick="Button1_Click" />
                        <input id="Reset1" type="reset" value="Reset" /></td>
                    <td class="auto-style2"></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="Label1" runat="server" ForeColor="#33CC33" Text=""></asp:Label>
                    </td>
                    <td class="col2"></td>
                </tr>
            </table>
        </div>
        <asp:HyperLink ID="hyperlinkBack" runat="server" BackColor="#00CC00" BorderColor="Black" BorderWidth="2px" ForeColor="Black" NavigateUrl="~/EmployeeHomePage.aspx">Back</asp:HyperLink>
        <asp:HyperLink ID="HyperLinkExistingCustomer" runat="server" ForeColor="#0033CC" NavigateUrl="~/JobCardExisting.aspx">Existing Customer</asp:HyperLink>
        </form>
    </body>
</html>
<script type="javascript">
    populateCountries("DropDownListCountry");
</script>
