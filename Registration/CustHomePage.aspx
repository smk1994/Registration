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
            <asp:Button ID="ServiceHistoryButton" runat="server" Text="Show Service History" OnClick="createVehicleListDropDown" /><br /><br />
            <asp:DropDownList ID="SelectVehicle" runat="server" OnSelectedIndexChanged="showServiceHistory" AutoPostBack="true" Visible="false"></asp:DropDownList><br /><br />
            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" /><br /><br /><br /><br />
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
        </div>
    </form>
</body>
</html>
