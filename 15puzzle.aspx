<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="15puzzle.aspx.cs" Inherits="_20201108_15puzzleASP._15puzzle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="./css/style.css" />
    <link rel="stylesheet" href="css/bootstrap.css" />
</head>
<body>
    <div class="stat">
        <div id="time">
            Time
            <br />
            <asp:Label id="lblTime" Text="0" runat="server" />
        </div>
        <div id="moves">
            Moves
            <br />
            <asp:Label id="lblMoves" Text="0" runat="server" />
        </div>
    </div>
    <form id="form1" runat="server">
        <asp:Panel ID="MainPanel" runat="server">
            <asp:Panel ID="Panel_1" runat="server" CssClass="row">
            </asp:Panel>
            <asp:Panel ID="Panel_2" runat="server" CssClass="row">
            </asp:Panel>
            <asp:Panel ID="Panel_3" runat="server" CssClass="row">
            </asp:Panel>
            <asp:Panel ID="Panel_4" runat="server" CssClass="row">
            </asp:Panel>            
            <asp:Panel ID="Panel_5" runat="server" CssClass="row">
            </asp:Panel>
        </asp:Panel>
    </form>
    <script src="js/myScript.js"></script>
</body>
</html>
