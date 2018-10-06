<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustHomePage.aspx.cs" Inherits="Registration.CustHomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="text-align:center;background-color:wheat">
    <form id="form1" runat="server">
        <div>
            <h1>Customer Home Page</h1>
            <asp:Label ID="LabelUserDetails" runat="server" Text=""></asp:Label><br /><br />
            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
        </div>
    </form>
</body>
</html>
