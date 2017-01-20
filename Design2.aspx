<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Design2.aspx.cs" Inherits="Design2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
  <li><a href="#news">Beneficiary</a></li>
  <li><a href="#contact">Transfer Funds</a></li>
  <li><a href="#contact">Transcation History</a></li>
  <li><a href="#contact">Money Sent</a></li>
   <li><a href="#contact">Money Received</a></li>
  <li style="float:right"><a href="#about">Log Out</a></li>
</ul>

</body>
</html>
