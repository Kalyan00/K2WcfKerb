<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebApp._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Web App</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Test Web App</h1>
        <h2>Logged in as: <asp:LoginName runat="server" /></h2>
        <p>
            <asp:Button ID="btnRun" runat="server" OnClick="btnRun_Click" Text="Connect to K2 Server" />
        </p>
    </div>
        <div>
            <asp:Panel runat="server" ID="pnlContainer">

            </asp:Panel>
        </div>
        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    </form>
</body>
</html>
