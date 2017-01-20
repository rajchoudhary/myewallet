<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Design.aspx.cs" Inherits="Design" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>

         body
         {
             background-image:url("2.png");
         }
        /*.btn
        {
           background-color: Transparent;
             background-repeat:no-repeat;
             border: none;
             cursor:pointer;
             overflow: hidden;
             display:block;
             height: 100px;
             width: 100px;
             border-radius: 50%;
             border: 1px solid red;
             margin-left:540px;
             margin-top:130px;
            
        }
        .btn:focus
        {
            outline:0;
        }
        .btn:hover
        {
            background-color:lightblue;
        }
        .btn2
        {
            background-color: Transparent;
             background-repeat:no-repeat;
             border: none;
             cursor:pointer;
             overflow: hidden;
             display:block;
            display:block;
            height: 100px;
            width: 100px;
            border-radius: 50%;
            border: 1px solid red;
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
        }

        
        .txtbox
        {
            height:40px;
            width:300px;
            margin-left:500px;
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

        /*.txtbox2
        {
            height:40px;
            width:300px;
            margin-left:500px;
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
            height:45px;
            width:305px;
            margin-left:500px;
            margin-top:20px;
            font-size: 30px;
            font-family:Arial;
           
        }

        .btn4
        {
             background-color: Transparent;
             background-repeat:no-repeat;
             border: none;
             cursor:pointer;
             overflow: hidden;
             display:block;
            display:block;
            height:45px;
            width:305px;
            margin-left:500px;
            margin-top:20px;
            font-size: 30px;
            font-family:Arial;
             border: 1px solid red;
            
             
        }

        p{
            margin-left:500px;
            font-size: 15px;
        }
        a{
            text-decoration:none;
        }*/*/
        ul {
    list-style-type: none;
    margin: 0;
    padding: 0;
    overflow: hidden;
    background-color: #333;
}

li {
    float: left;
    border-right:1px solid #bbb;
}

li:last-child {
    border-right: none;
}

li a {
    display: block;
    color: white;
    text-align: center;
    padding: 14px 16px;
    text-decoration: none;
}

li a:hover:not(.active) {
    background-color: #111;
}

.active {
    background-color: #4CAF50;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%--<table>
        <tr>
               <td><asp:Button ID="Button1"  Cssclass="btn" runat="server" Text="Button" /></td>
               <td><asp:Button ID="Button2"  Cssclass="btn2" runat="server" Text="Button2" /></td>
        </tr>
        </table>
        
            <asp:TextBox ID="TextBox1" CssClass="txtbox" runat="server" placeholder="Mobile No"></asp:TextBox>   
            <asp:TextBox ID="TextBox2" CssClass="txtbox2" runat="server" placeholder="Password" TextMode="Password" ></asp:TextBox>
       
            <asp:Button ID="Button3" CssClass="btn3" runat="server" Text="Button" OnClick="Button3_Click" />
            <p>Don't have a account yet?<a href="Register.aspx">Sign up!</a></p>
        <asp:Button ID="Button4" CssClass="btn4" runat="server" Text="Button" />--%>

        <%--<ul>
  <li><a class="active" href="#home">Home</a></li>
  <li><a href="#news">News</a></li>
  <li><a href="#contact">Contact</a></li>
  <li style="float:right"><a href="#about">About</a></li>
</ul>
            </div>
    </form>
</body>
</html>--%>

<!DOCTYPE html>
<html>
<head>
<style>
ul {
    list-style-type: none;
    margin: 0;
    padding: 0;
    overflow: hidden;
    background-color: #333;
}

li {
    float: left;
    border-right:1px solid #bbb;
}

li:last-child {
    border-right: none;
}

li a {
    display: block;
    color: white;
    text-align: center;
    padding: 14px 16px;
    text-decoration: none;
}

li a:hover:not(.active) {
    background-color: #111;
}

.active {
    background-color: #4CAF50;
}
</style>
</head>
<body>

<ul>
  <li><a class="active" href="#home">Home</a></li>
  <li><a href="#news">News</a></li>
  <li><a href="#contact">Contact</a></li>
  <li style="float:right"><a href="#about">About</a></li>
</ul>

</body>
</html>

