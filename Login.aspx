
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <meta name="e-wallet" content="An online e-wallet project developed by raj using ASP.NET and MSSQL" />
</head>
    <style>
        body
        {
            /*background-image : url("2.png");*/
             /*background-image : url("Background.jpg");*/
             background-image:url("testback.png");
        }

         .btn
        {
            /*background-color: Transparent;*/
             background-image:url("test.jpg");
             /*background-repeat:no-repeat;*/
             border: none;
             cursor:pointer;
             overflow: hidden;
             display:block;
             height: 100px;
             width: 100px;
             border-radius: 50%;
             border: 1px solid black;
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
             /*background-repeat:no-repeat;*/
             border: none;
             cursor:pointer;
             overflow: hidden;
             display:block;
            display:block;
            height: 100px;
            width: 100px;
            border-radius: 50%;
            border: 1px solid black;
            margin-left:30px;
            margin-top:130px;
            
        }
         .btn2:focus
        {
            outline:0;
        }
        .btn2:hover
        {
            background-color:yellow;
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
           background-image:url("phone.png");
           background-position: left;
            background-repeat: no-repeat;

        }

         input:focus
         {
             outline:none;
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
            /*margin-left:550px;*/
            font-size:15px;
            text-align: center;
            color:red;
        }
        p
        {
            /*margin-left:500px;*/
            font-size: 20px;
        }
        a
        {
            text-decoration:none;
            color:red;
        }
        .d
        {
            font-size: 17px;
            color: brown;
        }
    </style>
    <script>
        (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
         (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
            m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
            })(window,document,'script','https://www.google-analytics.com/analytics.js','ga');

            ga('create', 'UA-90192228-1', 'auto');
            ga('send', 'pageview');

    </script>
    
<body>
    <form id="form1" runat="server" defaultbutton="BtnLogin">
    <div>
    <center>
    <table>
        <tr>
            <td><asp:Button ID="BtnUser"  Cssclass="btn" runat="server"></asp:Button></td>
            <td><asp:Button ID="BtnRetailer"  Cssclass="btn2" runat="server" OnClick="BtnRetailer_Click"></asp:Button></td>
        </tr>
    </table>

        <asp:TextBox ID="TxtMobileNo" CssClass="txtbox" runat="server" TextMode="Number" placeholder=" Mobile No"></asp:TextBox><br />
        <asp:TextBox ID="TxtPassword" CssClass="txtbox2" runat="server"  placeholder="Password" TextMode="Password"></asp:TextBox>
        <asp:Button ID="BtnLogin" CssClass="btn3" runat="server" OnClick="BtnLogin_Click" />
        <p><a href="recoverypassword.aspx">Forgot My Password</a><br />
           Don't have a account yet?<a href="Register.aspx">Sign up!</a></p>
         <asp:Label ID="LblLoginStatus" CssClass="label" runat="server"></asp:Label>
        <br /><br />
        <asp:Label ID="LblContact" CssClass="d" runat="server" Text="E-wallet developed by U.RAJ, Contact: choudharuraj@gmail.com "></asp:Label><br />
       
     </center> 
    </div>
    <script>
        function button_click(TxtPassword, BtnLogin)
    {
            //debugger;
            if (window.event.keyCode == 13)
        {
                document.getElementById(BtnLogin).focus();
                document.getElementById(BtnLogin).click();
        }
    }
</script>
    </form>

    
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</body>
</html>
