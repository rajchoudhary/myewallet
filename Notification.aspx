<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Notification.aspx.cs" Inherits="Notification" %>

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

        .table
        {
            width: 30%;
            border: 1px solid black;
            color: black;
            text-align: center;
            background-color:white;
            height: 15;
            font-size: 18px;
        }

        .RowStyle
         {
            height: 50px;
         }
       
    </style>
<body>
    <form id="form1" runat="server">
    <div>
        <ul>
        <li><a  href="Home.aspx">Home</a></li>
        <li><a href="Beneficiary.aspx">Beneficiary</a></li>
        <li><a href="Transfer.aspx">Transfer Funds</a></li>
        <li><a href="history.aspx">History</a></li>
        <li><a href="sent.aspx">Money Sent</a></li>
        <li><a href="receiver.aspx">Money Received</a></li>
        <li><a class="active" href="#Notification">Notification</a></li>
        <li style="float:right"><a href="Login.aspx">Log Out</a></li>
    </ul>
      <center>
          <br />

        <asp:GridView ID="Gvnotification" Cssclass="table" RowStyle-CssClass="RowStyle" runat="server" EmptyDataText="No New Notification" ShowHeaderWhenEmpty="true"></asp:GridView>
      </center>
     </div>
    </form>
     <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</body>
</html>
