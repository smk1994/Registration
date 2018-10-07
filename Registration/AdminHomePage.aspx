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
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" Visible="False" AutoPostBack="True" OnSelectedIndexChanged="RadioButton1_CheckedChanged">
        </asp:RadioButtonList></center>
        <br />
        <asp:DropDownList runat="server" ID="vehiclelist" Visible="false" AutoPostBack="True" OnSelectedIndexChanged="vehiclelist_SelectedIndexChanged" ></asp:DropDownList>
        <br />
        <asp:DropDownList runat="server" ID="customerlist" Visible="false" AutoPostBack="True" OnSelectedIndexChanged="customerlist_SelectedIndexChanged"></asp:DropDownList>
        <br />
        <br />
        <asp:GridView style="text-align:center;" ID="GridView1" runat="server" BackColor="LightGoldenrodYellow" Font-Bold="True" Font-Size="Medium" CellPadding="2" BorderColor="Tan" BorderWidth="1px" ForeColor="Black">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
        </asp:GridView>
    </form>
    </body>
</html>
