<%@ Page Language="C#" AutoEventWireup="true" CodeFile="retailertransaction.aspx.cs" Inherits="retailertransaction" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <style>
        body
        {
            background-image: url("testback.png");
        }

        ul 
        {
            list-style-type: none;
            margin: 0;
            padding: 0;
            overflow: hidden;
            background-color: none;
            font-size: 17px;
        }

        li 
        {
            float: left;
            /*border-right:1px solid #bbb;*/
        }   

        li:last-child
        {
            border-right: none;
        }

        li a 
        {
            display: block;
            color: black;
            text-align: center;
            padding: 14px 16px;
            text-decoration: none;
        }

        li a:hover:not(.active) 
        {
            background-color: #4CAF50;
        }

       .active 
        {
            background-color: #4CAF50;
        }
    </style>
    <body>
    <form id="form1" runat="server">
    <div>
        <ul>
        <li><a  href="retailerhome.aspx">Home</a></li>
        <li><a href="retailerbeneficiary.aspx">Manage Beneficiary</a></li>
        <li><a class="active" href="#retailertransaction.aspx">Sender Login</a></li>
        <li><a href="CustomerTransfer.aspx">Transfer Funds</a></li>
        <li><a href="retailerhistory.aspx">Transcation History</a></li>
        <%--<li><a href="retailerdebit.aspx">Debit</a></li>--%>
        <li><a href="debithistory.aspx">Debit History</a></li>
        <li style="float:right"><a href="Login.aspx">Log Out</a></li>
    </ul>
        <center>
        <h3>Quick Remittance</h3>
        <table>
            <tr>
                <td><asp:Label ID="LBLMobileNo" runat="server" Text="Mobile No: "></asp:Label></td>
                <td><asp:TextBox ID="TxtMobileNo" runat="server" TextMode="Number"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="LblAmount" runat="server" Text="Amount: "></asp:Label></td>
                <td><asp:TextBox ID="TxtAmount" runat="server" TextMode="Number"></asp:TextBox></td>
            </tr>
        </table>
        <asp:Button ID="BtnSend" runat="server" Text="Send" OnClick="BtnSend_Click" />
        

        <h3>Sender Login</h3>
        <table>
            <tr>
                <td><asp:Label ID="LblLoginMobile" runat="server" Text="Mobile No"></asp:Label></td>
                <td><asp:TextBox ID="TxtLoginMobile" runat="server" TextMode="Number"  ></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="LblOTP" runat="server" Text="OTP"></asp:Label></td>
                <td><asp:TextBox ID="TxtOTP" runat="server" TextMode="Password" ></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Button ID="BtnGenerateOTP" runat="server" Text="Generate OTP" OnClick="BtnGenerateOTP_Click"></asp:Button></td>
                <td><asp:Button ID="BtnLogin" runat="server" Text="Log in" OnClick="BtnLogin_Click"></asp:Button></td>
            </tr>
        </table>
          <asp:Label ID="LblStatus" runat="server"></asp:Label> 
        </center>

    </div>
        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
    </form>
</body>
</html>
