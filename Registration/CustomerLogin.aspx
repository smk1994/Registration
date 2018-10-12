<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerLogin.aspx.cs" Inherits="Registration.CustomerLogin" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Login Page</title>
    <style>
        body
        {
            background-color:wheat;
            text-align:center;
        }
    </style>
</head>
<body>
    <h1>Login</h1>
    <form id="form2" runat="server">
        <div>
            <table style="margin:auto;border:5px solid white">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBoxUsername" runat="server" TextMode="SingleLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        </td>
                    <td>
                        <asp:Button ID="BtnLogin" runat="server" Text="Login" OnClick="BtnLogin_Click" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="LabelErrorMessage" runat="server" Text="Incorrect User Details" ForeColor="Red" ></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        
        <asp:Button ID="ForgotPassword" runat="server" OnClick="ForgotPasswordMethod" Text="Forgot Password" Visible="true"/><br />
        <asp:TextBox ID="forgotpasswordtextbox" runat="server" TextMode="Password" Visible="false" Text="Enter Your Registered"> Email ID" ForeColor="Black"></asp:TextBox>
        <asp:Button ID="ForgotPasswordButton" runat="server" OnClick="ForgotPasswordMethodSendEmail" Text="Send Email" Visible="false"/><br />
    </form>
</body>
</html>