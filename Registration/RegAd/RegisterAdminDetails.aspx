<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterAdminDetails.aspx.cs" Inherits="Registration.RegAd.RegisterAdminDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Register Admin" />
        <p>
            <asp:Label ID="SuccessRegister" runat="server" ForeColor="#0066CC" Visible="False"></asp:Label>
        </p>
    </form>
</body>
</html>
