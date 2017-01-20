<%@ Page Language="C#" AutoEventWireup="true" CodeFile="senderlogin.aspx.cs" Inherits="senderlogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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

       .load
       {
           font-size: 18px;
           font-weight: bold;
       }
    </style>
<body>
    <form id="form1" runat="server">
    <div>
    <ul>
        <li><a href="#home">Home</a></li>
        <li><a href="CustomerTransfer.aspx">Transfer Funds</a></li>
        <li><a class="active" href="retailertransaction.aspx">Sender Login</a></li>
        <li><a href="retailerhistory.aspx">Transcation History</a></li>
        <li><a href="retailerdebit.aspx">Debit</a></li>
        <li><a href="debithistory.aspx">Debit History</a></li>
        <li style="float:right"><a href="Login.aspx">Log Out</a></li>
    </ul>
    <%--<ul>
        <%--<li><a class="active" href="#home">Load Wallet</a></li>--%>
        <%--<li><a href="Transfer.aspx">Trasnfer To Wallet</a></li>--%>
        <%--<li><a href="payment.aspx">Make Payment</a></li>--%>
       <%-- <li style="float:right"><a href="Login.aspx">Log Out</a></li>--%>
   <%-- </ul>--%>
    <center>
        <asp:Label ID="LblLoad" Cssclass="load" runat="server" Text="LOAD MONEY   "></asp:Label><br />
        <asp:Label ID="LblNumber" runat="server"></asp:Label>
        <asp:TextBox ID="TxtAmount" runat="server"></asp:TextBox>
        <asp:Button ID="BtnSend" runat="server" Text="Send" OnClick="BtnSend_Click" />
        <br />
        
        <br />
        <br />
        <br />
        <asp:Label ID="LblReceive" Cssclass="load" runat="server" Text="DEBIT MONEY"></asp:Label><br />
        <asp:Label ID="LblPay"  runat="server" Text="Amount to pay"></asp:Label>
        <asp:TextBox ID="TxtPay" runat="server"></asp:TextBox>
        <asp:Button ID="BtnSend1" runat="server" Text="Receive" OnClick="BtnSend1_Click" style="height: 26px" />
        <br /><br />
        <%--<asp:Label ID="LblTransfer" Cssclass="load" runat="server" Text="Transfer To Contacts"></asp:Label><br />--%>
        <%--<asp:GridView ID="GvBenTransfer" Cssclass="transfer2" runat="server"  AutoGenerateColumns="false" EmptyDataText="Add people to contacts so send directly" ShowHeaderWhenEmpty="true">
                <Columns>
                    <asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:CheckBox ID="CbSelect"  runat="server"></asp:CheckBox>

                            </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Contacts" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                                <asp:Label ID="LblReceiver"  runat="server" Text='<%#Bind("beneficiary") %>'></asp:Label>   
                        </ItemTemplate>
                   </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Amount" ItemStyle-Width="125px">
                        <ItemTemplate>
                            <asp:TextBox ID="TxtBoxAmount" Width="97%" runat="server" Cssclass="box" TextMode="Number"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>

                    
                    <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="LblStat" Cssclass="status" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>--%>
          <%-- <asp:Button ID="Btntransfer" runat="server" Text="Send" OnClick="Btntransfer_Click"></asp:Button>--%>
        <asp:Label ID="LblStatus" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
