<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <style>
        body
        {
            background-image : url("2.png");
        }
    </style>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Menu ID="NavigationMenu" runat="server" CssClass="menu" EnableViewState="false" IncludeStyleBlock="false" Orientation="Vertical">
                    <Items>
                        <asp:MenuItem NavigateUrl="~/Login.aspx" Text="Home"/>
                        <asp:MenuItem NavigateUrl="~/.aspx" Text="About"/>
                        <asp:MenuItem NavigateUrl="#" Text="Buy"/>
                    </Items>
                </asp:Menu>
    </div>
    </form>
</body>
</html>
