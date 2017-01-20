<%@ Page Language="C#" AutoEventWireup="true" CodeFile="retailer.aspx.cs" Inherits="retailer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <style>
        body
        {
            background-image:url("Back2.jpg");
        }
        .btn
        {
            /*background-color: Transparent;*/
            background-image:url("test.jpg");
             background-repeat:no-repeat;
             border: none;
             cursor:pointer;
             overflow: hidden;
             display:block;
            height: 100px;
            width: 100px;
            border-radius: 50%;
            border: 3px solid black;
            /*margin-left:540px;*/
            margin-top:130px;
            
        }
        .btn:focus
        {
            outline:0;
        }

        .btn:hover
        {
            background-color:yellow;
             box-shadow: 0 12px 16px 0 rgba(0,0,0,0.24), 0 17px 50px 0 rgba(0,0,0,0.19);
        }

        .btn2
        {
            /*background-color: Transparent;*/
            background-image:url("cart.jpg");
             background-repeat:no-repeat;
             border: none;
             cursor:pointer;
             overflow: hidden;
             display:block;
            height: 100px;
            width: 100px;
            border-radius: 50%;
            border: 3px solid black;
            margin-left:30px;
            margin-top:130px;
            
        }
         .btn2:focus
        {
            outline:0;
        }
        .btn2:hover
        {
            background-color:lightblue;
             box-shadow: 0 12px 16px 0 rgba(0,0,0,0.24), 0 17px 50px 0 rgba(0,0,0,0.19);
        }

          .txtbox
        {
            height:40px;
            width:300px;
            /*margin-left:500px;*/
            margin-top:30px;
             font-family:Arial;
            /*font-weight:bold;*/
            font-style:bold;
            font-size: 30px;
           text-align: center;
           background-image:url("user.png");
           background-position: left;
            background-repeat: no-repeat;
        }

         .txtbox2
        {
            height:40px;
            width:300px;
            /*margin-left:500px;*/
            margin-top:20px;
            font-family:Arial;
            font-style: bold;
            font-size: 30px;
            background-image:url("key.jpg");
            background-repeat: no-repeat;
            text-align: center;
        }
        
         .btn3
        {
           /*background-color: Transparent;*/
           background-image:url("crop.png");
             background-repeat:no-repeat;
             border: none;
             cursor:pointer;
             overflow: hidden;
             display:block;
            display:block;
            height:45px;
            width:305px;
            /*margin-left:500px;*/
            margin-top:20px;
            font-size: 30px;
            font-family:Arial;
             /*border: 1px solid red;*/
           
        }

        .label
        {
            /*margin-left:500px;*/
            font-size:15px;
            text-align: center;
            color:red;
        }

    </style>
<body>
    <form id="form1" runat="server" defaultbutton="BtnLogin">
    <div>
        <center>
         <table>
          <tr>
           <td><asp:Button ID="BtnUser"  Cssclass="btn" runat="server" OnClick="BtnUser_Click"></asp:Button></td> 
            <td><asp:Button ID="BtnRetailer" Cssclass="btn2" runat="server"></asp:Button></td> 
          </tr>
          </table>
       
         <asp:TextBox ID="TxtUserName" CssClass="txtbox" runat="server" placeholder="Username" OnTextChanged="TxtUserName_TextChanged"></asp:TextBox><br />
         <asp:TextBox ID="TxtPassword" CssClass="txtbox2" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
         <asp:Button ID="BtnLogin" runat="server"  CssClass="btn3" OnClick="BtnLogin_Click"  />
         <asp:Label ID="LblRetailerLoginStatus" CssClass="label" runat="server"></asp:Label>
        
        </center>
    </div>
        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
    </form>
</body>
</html>
