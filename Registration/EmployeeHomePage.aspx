<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeHomePage.aspx.cs" Inherits="Registration.EmployeeHomePage" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="text-align:center;background-color:wheat">
    <form id="form1" runat="server">
        <div>
            <h1>Employee Home Page</h1>
            <asp:Label ID="LabelEmpDetails" runat="server" Text=""></asp:Label><br /><br />
            <asp:Button ID="CustomerRegistration" runat="server" OnClick="btnEmpRegister" Text="Create Job Card"></asp:Button><br /><br />
            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
        </div>
    </form>
</body>
</html>
