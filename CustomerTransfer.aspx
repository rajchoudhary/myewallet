<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerTransfer.aspx.cs" Inherits="CustomerTransfer" %>

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
         width:60%;
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
       .test
       {
          border-width: 2px 2px 2px 2px;
          border-color: red;
       }
 </style>
<body>
    <form id="form1" runat="server">
    <div>
        
        <ul>
        <li><a href="retailerhome.aspx">Home</a></li>
         <li><a href="retailerbeneficiary.aspx">Manage Beneficiary</a></li>
        <li><a href="retailertransaction.aspx">Sender Login</a></li>
        <li><a class="active" href="CustomerTransfer.aspx">Transfer Funds</a></li>
        <li><a href="retailerhistory.aspx">Transcation History</a></li>
        <%--<li><a href="retailerdebit.aspx">Debit</a></li>--%>
        <li><a href="debithistory.aspx">Debit History</a></li>
        <li style="float:right"><a href="Login.aspx">Log Out</a></li>
    </ul>
     <center>
            
            <br /><br />
            <%--<table <%--class="test"  style="width:auto;border:solid orange;padding-left:300px;padding-right:300px;padding-top:30px;padding-bottom:30px;/*background-color:white*/"--%>
                <%--<tr><center> 
                <td colspan="3" align="center"><h3>ADD BENEFICIARY</h3></td>

                </center></tr>
                 <tr>
                    <td><asp:Label ID="LblNumber" runat="server" Text="Mobile No"></asp:Label></td>
                    <td><asp:TextBox ID="TxtNumber" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                   <td><asp:Label ID="LblAddOtp" runat="server" Text="Enter OTP"></asp:Label></td> 
                    <td><asp:TextBox ID="TxtAddOtp" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Button ID="BtnAddViewUser" runat="server" Text="View User" OnClick="BtnAddViewUser_Click"></asp:Button></td>
                    <td><asp:Button ID="BtnAddGenOtp" runat="server" Text="Generate OTP To Verify"></asp:Button></td>
                    <td><asp:Button ID="BtnAddUser" runat="server" Text="ADD USER" OnClick="BtnAddUser_Click"></asp:Button></td>
                   
                </tr>
                <table>
                <tr><td><asp:Label ID="Label1" runat="server"></asp:Label></td><td><asp:Label ID="LblAddNo" runat="server"></asp:Label></td></tr>
                <tr><td><asp:Label ID="Label2" runat="server"></asp:Label></td><td><asp:Label ID="LblAddName" runat="server"></asp:Label></td></tr>
                <tr><td><asp:Label ID="Label3" runat="server"></asp:Label></td><td><asp:Label ID="LblAddAge" runat="server"></asp:Label></td></tr>
                <tr><td><asp:Label ID="Label4" runat="server"></asp:Label></td><td><asp:Label ID="LblAddGender" runat="server"></asp:Label></td></tr>
                </table>
            </table>
            <br />--%>
            

       <div <%--style="width:auto;border:solid blue;/*padding-left:30px;padding-right:30px;padding-top:30px;padding-bottom:30px*/ margin-left:200px;margin-right:200px"--%>>    
           <%-- <h3>TRANSFER TO BENEFICIARY</h3>--%>
           <h2><asp:Label ID="LblBal" runat="server"></asp:Label></h2>
    <table >
        <tr>
            <td><b><asp:Label ID="LblMobileno" runat="server" Text="Mobile No"></asp:Label></b></td>
            <td><asp:TextBox ID="TxtMobileNo" runat="server" TextMode="Number"></asp:TextBox></td>
            <td><asp:Button ID="BtnSearch" runat="server" Text="Search" OnClick="BtnSearch_Click"></asp:Button></td>
            <td><asp:Button ID="BtnClear" runat="server" Text="Clear" ></asp:Button></td>
        </tr>
    </table>
            <h3>OR</h3>
    <table>
        <tr>
            <td><b><asp:Label ID="LblUserRefId" runat="server" Text="UserRefId"></asp:Label></b></td>
            <td><asp:TextBox ID="TxtUserRefId" runat="server" TextMode="Number"></asp:TextBox></td>
            <td><asp:Button ID="btnUserSearch" runat="server" Text="Search" OnClick="btnUserSearch_Click"></asp:Button></td>
            <td><asp:Button ID="BtnRefClear" runat="server" Text="Clear"></asp:Button></td>
        </tr>
    </table>
            <br />
        
            <asp:GridView ID="GvCustomers" Cssclass="tab" runat="server" AutoGenerateColumns="false"  EmptyDataText="Add people to contacts" ShowHeaderWhenEmpty="true">
                <Columns >
                    <asp:TemplateField HeaderText="Select" >
                        <ItemTemplate ><asp:CheckBox ID="CbSelect" runat="server"></asp:CheckBox></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText ="UserRefID">
                        <ItemTemplate>
                        <asp:Label ID="LblAdder"  runat="server" Text='<%#Bind("UserId") %>'></asp:Label> 
                        </ItemTemplate>
                     </asp:TemplateField>
                    <asp:BoundField HeaderText="Name" DataField="Receiver" />  <%--Name--%>
                    <asp:BoundField HeaderText="Mobile No" DataField="MobileNo" />
                    
                     <%--<asp:BoundField HeaderText="Age" DataField="Age" />
                    <asp:BoundField HeaderText="Gender" DataField="Gender" />--%>
                    <asp:TemplateField HeaderText="Amount" ItemStyle-Width="190px" >
                        <ItemTemplate><asp:TextBox ID="txtAmount" runat="server" TextMode="Number" Width="98%"></asp:TextBox></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText ="Status">
                        <ItemTemplate>
                        <asp:Label ID="LblStatus"  runat="server"></asp:Label> 
                        </ItemTemplate>
                     </asp:TemplateField>
                </Columns>
                </asp:GridView>
            <br />
            <table>
                <tr>
                    <td><asp:Label ID="Lblotp" runat="server" Text="Enter OTP"></asp:Label></td>
                    <td><asp:TextBox ID="Txtotp" runat="server"></asp:TextBox></td>
                    <td><asp:Button ID="BtnGenotp" runat="server" Text="Generate OTP" OnClick="BtnGenotp_Click"></asp:Button></td>
                    <td><asp:Button ID="BtnSend" runat="server" Text="Send" OnClick="Button1_Click"></asp:Button></td>
                </tr>
            </table>
                
            <br />
                <asp:Label ID="LblStatus" runat="server" ></asp:Label>
        </div>
       </center>
    </div>
        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
    </form>
</body>
</html>
