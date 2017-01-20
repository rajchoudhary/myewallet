<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
</head>
    <style>
        body
        {
            background-image: url("testback.png");
        }

        .top
        {
            margin-top:50px;
            font-size: 18px;
        }

        .newuser
        {
            font-size:25px;
            font-weight: bold;
            margin-top:20px;
        }

        .button
        {
           width: 100px;
        }
    </style>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            <asp:Label ID="Label2" runat="server" Text="New User Registeration" CssClass="newuser"></asp:Label>
    <table class="top">
        <tr>
            <td><asp:Label ID="LblMobileNo" runat="server" Text="Mobile No: "></asp:Label></td>
            <td><asp:TextBox ID="TxtMobileNo" runat="server" TextMode="Number" OnTextChanged="TxtMobileNo_TextChanged"></asp:TextBox></td>
        </tr>
         <tr>
            <td><asp:Label ID="LblName" runat="server" Text="Name: "></asp:Label></td>
            <td><asp:TextBox ID="TxtName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="LblAge" runat="server" Text="Age: "></asp:Label></td>
            <td><asp:TextBox ID="TxtAge" runat="server" TextMode="Number"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="LblGender" runat="server" Text="Gender: "></asp:Label></td>
            <td><asp:TextBox ID="TxtGender" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label3" runat="server" Text="Your Security Question: "></asp:Label></td>
            <td><asp:TextBox ID="TxtQuestion" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label4" runat="server" Text="Answer: "></asp:Label></td>
            <td><asp:TextBox ID="TxtAnswer" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="LblPasword" runat="server" Text="Password: "></asp:Label></td>
            <td><asp:TextBox ID="TxtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
         <tr>
            <td><asp:Label ID="Label1" runat="server" Text="Transcation password: "></asp:Label></td>
            <td><asp:TextBox ID="TxtTransPassword" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
        </table>
        <table>
        <tr>
            <td><asp:Button ID="BtnBack" runat="server" CssClass="button" Text="Back" OnClick="BtnBack_Click" /></td>
            <td><center><asp:Button ID="BtnClear" runat="server" CssClass="button" Text="Clear" OnClick="BtnClear_Click" /></center></td>
            <td><asp:Button ID="BtnSave" runat="server" CssClass="button" Text="Register" OnClick="BtnSave_Click" /></td>
        </tr>
        </table>
        <br />
        <%--<asp:Button ID="BtnGenereateOTP" runat="server" Text="Generate OTP" OnClick="BtnGenereateOTP_Click"></asp:Button>
       <asp:Label ID="LblOtp" runat="server" Text="Label"></asp:Label>--%>
            <asp:Label ID="Lblstatus" runat="server"></asp:Label>
    </center>
    </div>
        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
    </form>
</body>
</html>
