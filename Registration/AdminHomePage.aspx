<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHomePage.aspx.cs" Inherits="Registration.AdminHomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Home Page</title>
</head>
<body style="text-align:center;background-color:wheat">
    <form id="form1" runat="server">
        <div>
            <h1>Admin Home Page</h1>
        </div>
        <asp:Label ID="AdminEmail" runat="server"></asp:Label>
        <br />
        <asp:Button ID="AdminLogout" runat="server" OnClick="Button1_Click" Text="Logout" />
        <br />
        <br />
    <asp:HyperLink ID="EmployeeRegistration" runat="server" ForeColor="#0033CC" NavigateUrl="~/EmployeeRegister.aspx">Register New Employee</asp:HyperLink>
        <br />
        <br />
        <asp:Button ID="ButtonViewDetails" runat="server" OnClick="ButtonViewDetails_Click" Text="Employee Details" />
        <br />
        <br />
        <asp:Button ID="ButtonCustomerViewDetails" runat="server" OnClick="ButtonCustomerViewDetails_Click" Text="Customer Details" />
        <br />
        <br />
        <asp:Button ID="ButtonViewJobCard" runat="server" OnClick="ButtonViewJobCard_Click" Text="View Service Details" />
        <br />
        <br />
        <center>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" Visible="False">
        </asp:RadioButtonList></center>
        <br />
        <br />
        <asp:GridView style="text-align:center;" ID="GridView1" runat="server" AutoGenerateColumns="True" BackColor="#FF99FF" Font-Bold="True" Font-Size="Large" CellPadding="7">
        </asp:GridView>
    </form>
    </body>
</html>
