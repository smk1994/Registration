<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeRegister.aspx.cs" Inherits="Registration.EmployeeRegister" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                        <asp:TextBox ID="TextBoxEmpUserName" runat="server" Width="100%"></asp:TextBox>
                    </td>
                    <td class="col2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxEmpUserName" ErrorMessage="User Name is required" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBoxEmpUserName" Display="Dynamic" ErrorMessage="Username must contain letter.s Length between 5-15" ForeColor="#FF0066" ValidationExpression="[a-zA-Z ]{4,25}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="col1">Email :</td>
                    <td>
                        <asp:TextBox ID="TextBoxEmpEmail" runat="server" Width="100%"></asp:TextBox>
                        <br />
                    </td>
                    <td class="col2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxEmpEmail" ErrorMessage="Email is required" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Email is Invalid" ForeColor="#FF0066" ControlToValidate="TextBoxEmpEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="col1">Password :</td>
                    <td>
                        <asp:TextBox ID="TextBoxEmpPassword" runat="server" TextMode="Password" Width="100%"></asp:TextBox>
                    </td>
                    <td class="col2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxEmpPassword" ErrorMessage="Password is required" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBoxEmpPassword" Display="Dynamic" ErrorMessage="Password Must Contain a lowercase and uppercase letter, number and any special character. Length betweeen 6-20" ForeColor="#FF0066" ValidationExpression="^((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%&]).{6,20})$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="col1">Address :</td>
                    <td>
                        <asp:TextBox ID="TextBoxEmpAddress" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
                    </td>
                    <td class="col2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" runat="server" ControlToValidate="TextBoxEmpAddress" ErrorMessage="Address Is Required" ForeColor="#FF0066" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="col1">Phone Number :</td>
                    <td>
                        <asp:TextBox ID="TextBoxEmpPhone" runat="server" TextMode="Number" Width="100%"></asp:TextBox>
                    </td>
                    <td class="col2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxEmpPhone" Display="Dynamic" ErrorMessage="Phone Number Is Required" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxEmpPhone" Display="Dynamic" ErrorMessage="Invalid Phone Number" ForeColor="#FF0066" ValidationExpression="^[0-9]{5,10}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style1">
                        <asp:Button ID="EmpButton1" runat="server" Text="Register" Width="104px" OnClick="EmpButton1_Click" />
                        <input id="Reset1" type="reset" value="Reset" /></td>
                    <td class="auto-style2"></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="EmpRegisterLabel" runat="server" ForeColor="#33CC33" Text=""></asp:Label>
                    </td>
                    <td class="col2"></td>
                </tr>
            </table>
        </div>
    </form>
    <asp:HyperLink ID="BackButton" runat="server" ForeColor="Blue" NavigateUrl="~/AdminHomePage.aspx">Back</asp:HyperLink>
</body>
</html>