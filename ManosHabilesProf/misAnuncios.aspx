<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="misAnuncios.aspx.cs" Inherits="ManosHabilesProf.misAnuncios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <div>
            <asp:Button ID="Button1" runat="server" Text="Regresar" />
            <asp:Button ID="Button3" runat="server" Text="Cerrar sesión" />
            <br />
            <br />
            MIS ANUNCIOS:<br />
            <asp:GridView ID="GridView1" runat="server" Height="322px" Width="579px">
            </asp:GridView>
            <br />
            -Elimina un anuncio si así lo quieres-<br />
            Anuncio seleccionado:
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <asp:Button ID="Button2" runat="server" Text="Eliminar" Width="104px" />
&nbsp;<asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
