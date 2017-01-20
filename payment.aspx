<%@ Page Language="C#" AutoEventWireup="true" CodeFile="payment.aspx.cs" Inherits="retailerusertransfer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
          <td><asp:Label ID="LblPay" runat="server" Text="Amount to pay"></asp:Label></td>
          <td><asp:TextBox ID="TxtPay" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Button ID="BtnSend" runat="server" Text="Send" OnClick="BtnSend_Click" style="height: 26px" /></td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
