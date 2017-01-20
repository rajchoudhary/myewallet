<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Beneficiary.aspx.cs" Inherits="Beneficiary" %>

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
        }
          .notification
        {
            border-radius: 50%;
            border: 1px solid black;
            background-color:orange;
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
        <li><a href="home.aspx">Home</a></li>
        <li><a class="active" href="#Beneficiary">Beneficiary</a></li>
        <li><a href="Transfer.aspx">Transfer Funds</a></li>
        <li><a href="history.aspx">History</a></li>
        <li><a href="sent.aspx">Money Sent</a></li>
        <li><a href="receiver.aspx">Money Received</a></li>
        <li><a href="Notification.aspx">Notifications <asp:Button ID="BtnNotification" CssClass="notification" runat="server"/></a></li>
        <li style="float:right"><a href="Login.aspx">Log Out</a></li>
    </ul>
    <center>
    <table>
        <tr>
              <td><b><asp:Label ID="LblBenNo" runat="server" Text="Enter Beneficiary No: "></asp:Label></b></td>
              <td><asp:TextBox ID="TxtBenNo" runat="server"></asp:TextBox></td>
               <td><asp:Button ID="BtnAdd" runat="server" Text="Add" OnClick="BtnAdd_Click"></asp:Button></td>
         </tr>    
    </table>
        <br />
        <br />
    <table>
            <tr>
                <td><asp:Label ID="LblTrMobileNo" runat="server" ></asp:Label></td>
                <td><asp:Label ID="LblShTrMobileNo" runat="server" ></asp:Label></td>
            </tr>
            <tr>
                <td><asp:Label ID="LblTrName" runat="server" ></asp:Label></td>
                <td><asp:Label ID="LblShTrName" runat="server" ></asp:Label></td>
            </tr>
            <tr>
                <td><asp:Label ID="LblTrGender" runat="server" ></asp:Label></td>
                <td><asp:Label ID="LblShTrGender" runat="server" ></asp:Label></td>
            </tr>
            <tr>
                <td><asp:Label ID="LblTrAge" runat="server" ></asp:Label></td>
                <td><asp:Label ID="LblShTrAge" runat="server" ></asp:Label></td>
            </tr>
        </table>
        <asp:Label ID="LblStatus" runat="server"></asp:Label>
        <br />
        
        <p><h3>Your Contacts</h3></p>
        <asp:GridView ID="GvBeneficiary" Cssclass="table" runat="server" AutoGenerateColumns="false" EmptyDataText="Add people to contacts" ShowHeaderWhenEmpty="true">
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox" runat="server"></asp:CheckBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Contacts">
                    <ItemTemplate>
                        <asp:Label ID="LblContact"  runat="server" Text='<%#Bind("beneficiary") %>'></asp:Label> 
                    </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <asp:Button ID="BtnDelete" runat="server" Text="Delete" CssClass="del" OnClick="BtnDelete_Click1"></asp:Button>
    </center>
    </div>
    </form>
     <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</body>
</html>
