
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Transfer.aspx.cs" Inherits="Transfer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Transfer</title>
</head>
    <style>
        body
        {
            background-image:url("testback.png");
            /*background-image:url("test5.jpg");*/
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

         /*.table
        {
            width: 35%;
            border: 1px solid black;
            color: black;
            text-align: center;
        }*/

         /*.box
         {
             width: 275px;
         }*/

         .transfer
         {
            margin-left:100px;
            margin-top: 70px;
            float:left;
            width:35%;
              
         }

         .transfer2
         {
             /*float: left;*/
             width:80%;
             float:right;
             margin-right:70px;
             margin-top: 10px;
             text-align: center;
         }

         .or
         {
             width:10%;
             float:left;
             margin-left:25px;

         }

         .buttons
         {
             margin-left:170px;
         }
         .send
         {
             margin-left:852px;
         }
         h2
         {
             margin-top:50px;
             text-align: center;
             
         }
          h1
         {
             text-align: center;
            
         }

        .status
        {
            text-align: center;
        }

        .button
        {
            height: 30px;
            border-radius: 4px;
            background-color: white;
        }

        .text
        {
            font-size: 18px;
        }

        .details
        {
            margin-left:200px;
        }

        .stat
        {
            font-size: 18px; 
        }
         .notification
        {
            border-radius: 50%;
            border: 1px solid black;
            background-color:orange;
        }

         .note
         {
            color: red;
         }
    </style>
<body>
    <form id="form1" runat="server">
    <div>
      <ul>
        <li><a href="Home.aspx">Home</a></li>
        <li><a href="Beneficiary.aspx">Beneficiary</a></li>
        <li><a class="active" href="Transfer.aspx">Transfer Funds</a></li>
        <li><a href="history.aspx">History</a></li>
        <li><a href="sent.aspx">Money Sent</a></li>
        <li><a href="receiver.aspx">Money Received</a></li>
        <li><a href="Notification.aspx">Notifications <asp:Button ID="BtnNotification" CssClass="notification" runat="server"/></a></li>
        <li style="float:right"><a href="Login.aspx">Log Out</a></li>
    </ul>
    
        <h2><asp:Label ID="LblTAvBal" runat="server"></asp:Label></h2>
         <h1>
             <asp:Label ID="Label1" runat="server" Text="Rs "></asp:Label><asp:Label ID="LblAvbal" runat="server" Text="Label"></asp:Label></h1>
        
        <table class="transfer">
            <tr>
                <td><b><asp:Label ID="LblTransferMobile" runat="server" Text="Mobile No: "></asp:Label></b></td>
                <td><b><asp:TextBox ID="TxtTransferMobile" runat="server" TextMode="Number"></asp:TextBox></b></td>
            </tr>
            <tr>
                <td><b><asp:Label ID="LblAmount" runat="server" Text="Amount "></asp:Label><b></td>
                <td><b><asp:TextBox ID="TxtAmount" runat="server" TextMode="Number"></asp:TextBox><b></td>
            </tr>
            <tr>
            <td><asp:Label ID="LblTranscat" runat="server" Text="OTP" ></asp:Label></td> 
            <td><asp:TextBox ID="TxtTransact" runat="server" TextMode="Password"></asp:TextBox></td> 
            </tr>
            <tr>
                <td  align="center" colspan="2">
                <asp:Button ID="BtnReceiver" CssClass="button" runat="server" Text="View Receiver" OnClick="BtnReceiver_Click"></asp:Button>
                <asp:Button ID="BtnSendClear" CssClass="button" runat="server" Text="Generate OTP" OnClick="BtnSendClear_Click"></asp:Button>
                <asp:Button ID="BtnSend" CssClass="button" runat="server" Text="Send" OnClick="BtnSend_Click"></asp:Button>
                    </td>
            </tr>
        </table>
        <table class="or">
            <tr>
                <td>
                    <h2>OR</h2>
                </td>
            </tr>
        </table>
        <div  runat="server" id="divgrdview" style="overflow-x:auto;height:250px">
        <asp:GridView ID="GvBenTransfer" Cssclass="transfer2" runat="server"  AutoGenerateColumns="false" EmptyDataText="Add people to contacts so send directly" ShowHeaderWhenEmpty="true">
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
            </asp:GridView>
            <br />
            </div>
            
          
     
        <table class="details">
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
        
        
        <table class="send" style="/*width:400px;*/margin-left:59%">
            <tr style= "width:500px">
               <td style= "width:50px"><asp:Label ID="LblTransaction" Cssclass="text" runat="server" Text="OTP"></asp:Label></td> 
                <td><asp:TextBox ID="TxtTransaction" Width="125px" Height="25px" runat="server" TextMode="Password" OnTextChanged="TxtTransaction_TextChanged"></asp:TextBox></td> 
                <td><asp:Button ID="BtnGenerateOtp" CssClass="button" runat="server" Text="Generate OTP" OnClick="BtnGenerateOtp_Click" /></td> 
                <td><asp:Button ID="BtnTest" CssClass="button" runat="server" Text="Send" OnClick="BtnTest_Click" /></td>
            </tr>
            </table>
         <center><asp:Label ID="LblVal" Cssclass="stat" runat="server"></asp:Label><br />
             <asp:Label ID="Label2" Cssclass="note" runat="server" Text="Note: Instead of OTP the Transaction Password can also be used to carry out the transaction"></asp:Label>
         </center>

            <%--<h3>OR</h3>--%>
    </div>
    </form>
     <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</body>
</html>
