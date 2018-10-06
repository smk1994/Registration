<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobCardExisting.aspx.cs" Inherits="Registration.JobCardExisting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Job Card</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
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
        <table class="auto-style1">
            <tr>
                <td>Select Email:</td>
                <td>
        <asp:DropDownList ID="DropDownListSelectCustomerEmail" runat="server" AutoPostBack="true" >
        </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Vehicle Number:</td>
                <td>
                    <asp:TextBox ID="TextBoxVehicleNumber" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Brand:</td>
                <td>
                    <asp:TextBox ID="TextBoxVehicleBrand" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Model:</td>
                <td>
                    <asp:TextBox ID="TextBoxVehicleModel" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Engine Number:</td>
                <td>
                    <asp:TextBox ID="TextBoxVehicleEngineNumber" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Chassis Number:</td>
                <td>
                    <asp:TextBox ID="TextBoxVehicleChassisNumber" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Vehicle Problems:</td>
                <td>
                    <asp:TextBox id="TextBoxVehicleProblem" runat="server" width="100%"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <p>
&nbsp;<asp:Button ID="RegisterJobCard" runat="server" OnClick="RegisterJobCard_Click" Text="Register Job Card" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input id="Reset1" type="reset" value="Reset" /></p>
        <asp:Label ID="JobCardLabel" runat="server"></asp:Label>
    </form>
    <asp:HyperLink ID="hyperlinkBack" runat="server" BackColor="#00CC00" BorderColor="Black" BorderWidth="2px" ForeColor="Black" NavigateUrl="~/Register.aspx">Back</asp:HyperLink>
</body>
</html>
