<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Winner.aspx.cs" Inherits="_20201108_15puzzleASP.Winner" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="imgWin" runat="server" />
        </div>
        Time: 
        <asp:Label ID="lblResTime" runat="server" Text="0"></asp:Label>
        <br />
        Moves: 
        <asp:Label ID="lblResMove" runat="server" Text="0"></asp:Label>
        <div>
            <asp:Button ID="restart" runat="server" Text="New game!!!" OnClick="restart_Click" />
        </div>
    </form>
</body>
</html>
