<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuAdmin.aspx.cs" Inherits="ManosHabiles.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Menu Administrador&nbsp;
        <br />
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Revisar Reportes/ Banear" />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Hacer Reportes" />
        <br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Agregar a un Administrador</asp:LinkButton>
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Cerrar sesión" />
        <br />
    </form>
</body>
</html>
