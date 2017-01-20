<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sent.aspx.cs" Inherits="Beneficiary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <style>
        body
        {
            /*background-image: url("2.png");*/
            background-image:url("testback.png");
        }
        
        ul 
        {
            list-style-type: none;
            margin: 0;
            padding: 0;
            overflow: hidden;
            background-image: none;
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
        
        .table
        {
            width: 80%;
            border: 1px solid black;
            color: black;
            text-align: center;
        }

        .date
        {
           margin-top:50px;
        }

        .dateenter
        {
            text-align:center;
            height:25px;
            font-size: 20px;
            width: 200px;
        }

        .datelabel
        {
            font-size: 20px;
        }

        .button
        {
            height: 30px;
            width:30px;
            background-image: url("searchicon.png");
            background-repeat: no-repeat;
        }

        .header
        {
            height: 25px;
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
        <li><a href="home.aspx">Home</a></li>
        <li><a href="Beneficiary.aspx">Beneficiary</a></li>
        <li><a href="Transfer.aspx">Transfer Funds</a></li>
        <li><a href="history.aspx">History</a></li>
        <li><a class="active" href="#sent">Money Sent</a></li>
        <li><a href="receiver.aspx">Money Received</a></li>
        <li><a href="Notification.aspx">Notifications <asp:Button ID="BtnNotification" CssClass="notification" runat="server"/></a></li>
        <li style="float:right"><a href="Login.aspx">Log Out</a></li>
    </ul>
        <br />
        <br />
        <center>
        <table Cssclass="date">
                <td><b><asp:Label ID="LblReceiverName" Cssclass="datelabel" runat="server" Text="Name of Receiver: "></asp:Label></b></td>
                <td><asp:TextBox ID="TxtReceiverName"  Cssclass="dateenter" runat="server"></asp:TextBox></td>
                <td><asp:Button ID="BtnSearch" Cssclass= "button" runat="server"  OnClick="BtnSearch_Click"></asp:Button></td>
        </table>
        </center>
        <br />
        <br />
        <center>
            <asp:GridView ID="GvSent" Cssclass="table" runat="server" EmptyDataText="No Transactions To Show" ShowHeaderWhenEmpty="true"></asp:GridView>
        </center>
        <br />
        <br />
        <br />
    </div>
    </form>
     <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</body>
</html>
