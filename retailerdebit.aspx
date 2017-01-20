<%@ Page Language="C#" AutoEventWireup="true" CodeFile="retailerdebit.aspx.cs" Inherits="retailerdebit" %>

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
        <li><a href="retailertransaction.aspx">Customers</a></li>
        <li><a href="CustomerTransfer.aspx">Transfer Funds</a></li>
        <li><a href="retailerhistory.aspx">Transcation History</a></li>
        <li><a class="active" href="retailerdebit.aspx">Debit</a></li>
        <li><a href="debithistory.aspx">Debit History</a></li>
        <li style="float:right"><a href="Login.aspx">Log Out</a></li>
    </ul>
       
        <center>
         <table>
        <tr>
            <td><b><asp:Label ID="LblMobileno" runat="server" Text="Mobile No"></asp:Label></b></td>
            <td><asp:TextBox ID="TxtMobileNo" runat="server"></asp:TextBox></td>
            <td><asp:Button ID="BtnSearch" runat="server" Text="Search" OnClick="BtnSearch_Click" ></asp:Button></td>
            <td><asp:Button ID="BtnClear" runat="server" Text="Clear" ></asp:Button></td>
        </tr>
    </table>
            <h3>OR</h3>
    <table>
        <tr>
            <td><b><asp:Label ID="LblUserRefId" runat="server" Text="UserRefId"></asp:Label></b></td>
            <td><asp:TextBox ID="TxtUserRefId" runat="server"></asp:TextBox></td>
            <td><asp:Button ID="btnUserSearch" runat="server" Text="Search" OnClick="btnUserSearch_Click"  ></asp:Button></td>
            <td><asp:Button ID="BtnRefClear" runat="server" Text="Clear"></asp:Button></td>
        </tr>
    </table>
    <br />
            <asp:GridView ID="GvDebit" CssClass="tab" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:CheckBox ID="CbSelect" runat="server"></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="LblRemove" runat="server"  Text='<%#Bind("UserRefID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField HeaderText="Name" DataField="Name" />
                    <asp:BoundField HeaderText="Mobile No" DataField="MobileNo" />
                    <asp:BoundField HeaderText="Age" DataField="Age" />
                    <asp:BoundField HeaderText="Gender" DataField="Gender" />
                     <asp:TemplateField ItemStyle-Width="190px" HeaderText="Amount">
                        <ItemTemplate>
                            <asp:TextBox ID="TxtRemoveAmount" runat="server" TextMode="Number" Width="98%"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="BtnSend" runat="server" Text="Debit" OnClick="BtnSend_Click" />
    </center>
    </div>
    </form>
</body>
</html>
