<%@ Page Language="C#" AutoEventWireup="true" CodeFile="retailerhome.aspx.cs" Inherits="retailerhome" %>

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
         .display
         {
            width:50%;
            font-size: 28px;
            text-align: center;
            
        }
        .name
        {
            font-size: 30px;
            text-align:center;
            font-weight: bold;
        }
</style>
<body>
    <form id="form1" runat="server">
    <div>
        <ul>
        <li><a class="active" href="#home">Home</a></li>
        <li><a href="retailerbeneficiary.aspx">Manage Beneficiary</a></li>
        <li><a href="retailertransaction.aspx">Sender Login</a></li>
        <li><a href="CustomerTransfer.aspx">Transfer Funds</a></li>
        <li><a href="retailerhistory.aspx">Transcation History</a></li>
        <li><a href="debithistory.aspx">Debit History</a></li>
        <li style="float:right"><a href="Login.aspx">Log Out</a></li>
    </ul>
   <%-- <table>
        <tr>
            <td><asp:Button ID="BtnHome" runat="server" Text="Home" /></td>
             <td><asp:Button ID="BtnCustomers" runat="server" Text="Customers" OnClick="BtnCustomers_Click" /></td>
            <td><asp:Button ID="BtnFlushBalance" runat="server" Text="Add Balance" OnClick="BtnFlushBalance_Click" /></td>
             <td><asp:Button ID="BtnHistory" runat="server" Text="History" OnClick="BtnHistory_Click" /></td>
             <td><asp:Button ID="BtnDebit" runat="server" Text="Debit" OnClick="BtnDebit_Click" /></td>
            <td><asp:Button ID="BtnDebitHistory" runat="server" Text="Debit History" OnClick="BtnDebitHistory_Click" /></td>
            <td><asp:Button ID="BtnLogout" runat="server" Text="Logout" OnClick="BtnLogout_Click" /></td>

           
        </tr>
    </table>--%>
    
    <center><asp:Image ID="Imgguy" runat="server" Imageurl="~/guy.png"/></center><br />
        <center>
             <div class="name">
           <%-- <asp:Label ID="LblName" runat="server" Text="Name: "></asp:Label>--%>
            <asp:Label ID="LblShName" runat="server" CssClass="name"></asp:Label><br />
            <asp:Label ID="LblFunds" runat="server"></asp:Label>
            </div>
        <table class="display"><br /><br /
        <tr>
            <td><asp:Label ID="LblUsername" runat="server" Text="Username: "></asp:Label></td>
            <td><asp:Label ID="LblShUsername" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="LblMobileNo" runat="server" Text="Mobile No: "></asp:Label></td>
            <td><asp:Label ID="LblShMobileNo" runat="server"></asp:Label></td>
        </tr>
        
        <tr>
            <td><asp:Label ID="LblAge" runat="server" Text="Age: "></asp:Label></td>
            <td><asp:Label ID="LblShAge" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="LblGender" runat="server" Text="Gender: "></asp:Label></td>
            <td><asp:Label ID="LblShGender" runat="server"></asp:Label></td>
        </tr>
       </table>
      </center>
    </div>
        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
    </form>
</body>
</html>
