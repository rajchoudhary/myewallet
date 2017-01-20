<%@ Page Language="C#" AutoEventWireup="true" CodeFile="debithistory.aspx.cs" Inherits="debithistory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
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

       .tab
       {
           width: 50%;
           text-align: center;
       }
    </style>
    <form id="form1" runat="server">
    <div>
        <ul>
        <li><a  href="retailerhome.aspx">Home</a></li>
        <li><a href="retailerbeneficiary.aspx">Manage Beneficiary</a></li>
        <li><a href="retailertransaction.aspx">Sender Login</a></li>
        <li><a href="CustomerTransfer.aspx">Transfer Funds</a></li>
        <li><a href="retailerhistory.aspx">Transcation History</a></li>
        <%--<li><a href="retailerdebit.aspx">Debit</a></li>--%>
        <li><a class="active" href="debithistory.aspx">Debit History</a></li>
        <li style="float:right"><a href="Login.aspx">Log Out</a></li>
    </ul><br /><br /><br />
        <center>
        <asp:GridView ID="GvDebithistory" CssClass="tab" runat="server"  EmptyDataText="No Transactions To Show" ShowHeaderWhenEmpty="true">
        </asp:GridView>
        </center>
    </div>
        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
    </form>
</body>
</html>
