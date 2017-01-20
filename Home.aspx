<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
</head>
    <style>
        body
        {
            background-image:url("testback.png");
            /*background-image:url("test6.jpg");*/
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

        table 
        {
            border-collapse: collapse;
            border-style: hidden;
            
        }

        table tr
        {
            border: 1px solid black;
            width: 100%;
        }

        .display{
            width:50%;
            font-size: 28px;
            text-align: center;
            
        }
        .name
        {
            font-size: 30px;
            text-align:center;
        }

        .notification
        {
            border-radius: 50%;
            border: 1px solid black;
            background-color:orange;
        }
    
    </style>
<body>
    <form id="form1" runat="server">
    <div>
      <ul>
        <li><a class="active" href="#home">Home</a></li>
        <li><a href="Beneficiary.aspx">Beneficiary</a></li>
        <li><a href="Transfer.aspx">Transfer Funds</a></li>
        <li><a href="history.aspx">History</a></li>
        <li><a href="sent.aspx">Money Sent</a></li>
        <li><a href="receiver.aspx">Money Received</a></li>
        <li><a href="Notification.aspx">Notifications <asp:Button ID="BtnNotification" CssClass="notification" runat="server" OnClick="BtnNotification_Click"/></a></li>
        <li style="float:right"><a href="Login.aspx">Log Out</a></li>
    </ul>
        <center><asp:Image ID="Imgguy" runat="server" /></center>
            <%--<br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />--%>
            <div class="name">
                    <%--<asp:Label ID="LblName" runat="server" Text="Name: "></asp:Label>--%>
                    <b><asp:Label ID="LblShName" runat="server"></asp:Label></b>
                    <br /><br />
                    <asp:Label ID="LblFunds" runat="server" Text="Funds Available: "></asp:Label><asp:Label ID="Label1" runat="server" Text="Rs "></asp:Label>
                    <b><asp:Label ID="LblShFunds" runat="server"></asp:Label></b>
            </div>
            <br /><br /><%--<br /><br />--%>
        <center>
         <table class="display">
             <tr>
                    <td><asp:Label ID="LblMobileNo" runat="server" Text="Mobile Number "></asp:Label></td>
                    <td><asp:Label ID="LblShMobileNo" runat="server"></asp:Label></td>
            </tr>
        
            <tr>
                    <td><asp:Label ID="LblAge" runat="server" Text="Age "></asp:Label></td>
                    <td><asp:Label ID="LblShAge" runat="server"></asp:Label></td>
            </tr>

            <tr>
                    <td><asp:Label ID="LblGender" runat="server" Text="Gender "></asp:Label></td>
                    <td><asp:Label ID="LblShGender" runat="server"></asp:Label></td>
            </tr>
       </table>
      </center>
       
    </div>
    </form>
     <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</body>
</html>
