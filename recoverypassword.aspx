<%@ Page Language="C#" AutoEventWireup="true" CodeFile="recoverypassword.aspx.cs" Inherits="recoverypassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <style>
        body
        {
            background-image:url("testback.png");
        }

        .btn
        {
            width:70px;
        }

        .text
        {
            font-size: 18px;
        }

        .back
        {
            width: 70px;
            height: 25px;
        }

       
    </style>
<body>
   
   
    <form id="form1" runat="server">
     <asp:Button ID="BtnBack" runat="server" CssClass="back"  Text="Back" OnClick="BtnBack_Click1" />
     <center>
     <div>
    <table>
        <tr>
            <td><asp:Label ID="LblMobileNo" CssClass="text" runat="server" Text="Mobile No: "></asp:Label></td>
            <td><asp:TextBox ID="TxtMobileNo" runat="server"></asp:TextBox></td>
            <td><asp:Button ID="BtnSearch" CssClass="btn" runat="server" Text="Search" OnClick="BtnSearch_Click" /></td>
        </tr>
        <tr>
            <td><asp:Label ID="LblSecurity" CssClass="text" runat="server" Text="Security Question: "></asp:Label></td>
             <td><asp:Label ID="LblQuestion" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="LblAnswer" CssClass="text" runat="server" Text="Answer: "></asp:Label></td>
            <td><asp:TextBox ID="TxtAnswer" runat="server"></asp:TextBox></td>
            <td><asp:Button ID="BtnEnter" CssClass="btn" runat="server" Text="Enter" OnClick="BtnEnter_Click" /></td>
        </tr>
   
         <tr>
            <td><asp:Label ID="LblChangePassword" CssClass="text" runat="server" Text="Change Password: "></asp:Label></td>
            <td><asp:TextBox ID="TxtChangePassword" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="LblConfirmPassword" CssClass="text" runat="server" Text="Confirm Password: "></asp:Label></td>
            <td><asp:TextBox ID="TxtConfirmPassword" runat="server"></asp:TextBox></td>
            <td><asp:Button ID="BtnChange" CssClass="btn" runat="server" Text="Change" OnClick="BtnChange_Click" /></td>
        </tr>
     </table>  
        <asp:Label ID="LblStatus" CssClass="text" runat="server"></asp:Label>
    </div>
    </form>
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
  </center>
</body>
</html>
