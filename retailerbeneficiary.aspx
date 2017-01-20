<%@ Page Language="C#" AutoEventWireup="true" CodeFile="retailerbeneficiary.aspx.cs" Inherits="retailerbeneficiary" %>

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
         width:40%;
         text-align:center;
         margin-top: 50px;
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

       .te
       {
           font-weight: bold;
           font-size: 21px;
       }
        .del
        {
            width: 75px;
            height: 30px;
            font-size: 18px;
        }
    </style>
<body>
    <form id="form1" runat="server">
    <div>
      <ul>
        <li><a href="retailerhome.aspx">Home</a></li>
        <li><a class="active" href="retailerbeneficiary.aspx">Manage Beneficiary</a></li>
        <li><a href="retailertransaction.aspx">Sender Login</a></li>
        <li><a  href="CustomerTransfer.aspx">Transfer Funds</a></li>
        <li><a href="retailerhistory.aspx">Transcation History</a></li>
        <%--<li><a href="retailerdebit.aspx">Debit</a></li>--%>
        <li><a href="debithistory.aspx">Debit History</a></li>
        <li style="float:right"><a href="Login.aspx">Log Out</a></li>
    </ul>
        <center>
        <table <%--class="test"  style="width:auto;border:solid orange;padding-left:300px;padding-right:300px;padding-top:30px;padding-bottom:30px;/*background-color:white*/"--%>>
                <tr><center> 
                <td colspan="3" align="center"><h3>ADD BENEFICIARY</h3></td>

                </center></tr>
                 <tr>
                    <td><asp:Label ID="LblNumber" runat="server" Text="Mobile No"></asp:Label></td>
                    <td><asp:TextBox ID="TxtNumber" runat="server" TextMode="Number"></asp:TextBox></td>
                </tr>
                <tr>
                   <td><asp:Label ID="LblAddOtp" runat="server" Text="Enter OTP"></asp:Label></td> 
                    <td><asp:TextBox ID="TxtAddOtp" runat="server" TextMode="Number"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Button ID="BtnAddViewUser" runat="server" Text="View User" OnClick="BtnAddViewUser_Click"></asp:Button></td>
                    <td><asp:Button ID="BtnAddGenOtp" runat="server" Text="Generate OTP To Verify" OnClick="BtnAddGenOtp_Click"></asp:Button></td>
                    <td><asp:Button ID="BtnAddUser" runat="server" Text="ADD USER" OnClick="BtnAddUser_Click"></asp:Button></td>
                   
                </tr>
                <table>
                <tr><td><asp:Label ID="Label1" runat="server"></asp:Label></td><td><asp:Label ID="LblAddNo" runat="server"></asp:Label></td></tr>
                <tr><td><asp:Label ID="Label2" runat="server"></asp:Label></td><td><asp:Label ID="LblAddName" runat="server"></asp:Label></td></tr>
                <tr><td><asp:Label ID="Label3" runat="server"></asp:Label></td><td><asp:Label ID="LblAddAge" runat="server"></asp:Label></td></tr>
                <tr><td><asp:Label ID="Label4" runat="server"></asp:Label></td><td><asp:Label ID="LblAddGender" runat="server"></asp:Label></td></tr>
                </table>
            </table>
            <asp:Label ID="LblStatus" runat="server"></asp:Label><br /><br />
            <asp:Label ID="Label5" runat="server" Text="Your Contacts" CssClass="te"></asp:Label>
            <asp:GridView ID="GvCustomers" Cssclass="tab" runat="server" AutoGenerateColumns="false" EmptyDataText="Add people to contacts" ShowHeaderWhenEmpty="true">
                <Columns >
                    <asp:TemplateField HeaderText="Select" >
                        <ItemTemplate ><asp:CheckBox ID="CbSelect" runat="server"></asp:CheckBox></ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText ="Name">
                        <ItemTemplate>
                        <asp:Label ID="LblAdder"  runat="server" Text='<%#Bind("Receiver") %>'></asp:Label> 
                        </ItemTemplate>
                     </asp:TemplateField>    
                 </Columns>
                </asp:GridView>
            <br />
            <br />
            <asp:Button ID="BtnDelete" runat="server" CssClass="del" Text="Delete" OnClick="BtnDelete_Click"></asp:Button>

            </center>
    </div>
        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
    </form>
</body>
</html>
