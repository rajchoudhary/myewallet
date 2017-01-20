
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="retailerhistory.aspx.cs" Inherits="retailerhistory" %>

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

        .tab
        {
            width:80%;
            text-align:center;
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
        <div>
        <ul>
        <li><a  href="retailerhome.aspx">Home</a></li>
        <li><a href="retailerbeneficiary.aspx">Manage Beneficiary</a></li>
        <li><a href="retailertransaction.aspx">Sender Login</a></li>
        <li><a href="CustomerTransfer.aspx">Transfer Funds</a></li>
        <li><a class="active" href="retailerhistory.aspx">Transcation History</a></li>
        <%--<li><a href="retailerdebit.aspx">Debit</a></li>--%>
        <li><a href="debithistory.aspx">Debit History</a></li>
        <li style="float:right"><a href="Login.aspx">Log Out</a></li>
    </ul>
        
            <br /><br /><br />
    <center>
         <asp:GridView ID="GvHistory" runat="server" CssClass="tab"  EmptyDataText="Add people to contacts" ShowHeaderWhenEmpty="true" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
         </asp:GridView>
    </center>    
    </div>
        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
    </form>
</body>
</html>
