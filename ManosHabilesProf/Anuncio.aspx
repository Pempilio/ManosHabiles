<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Anuncio.aspx.cs" Inherits="ManosHabilesProf.Anuncio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Anuncio</title>
    <style type="text/css">
        .auto-style1 {
            color: #0000FF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Anuncio que usted eligió</h2>
            <p>
                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Ir al buzón" />
&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Volver al menú" OnClick="Button1_Click" />
            </p>
            <br />
            Nombre del cliente:
            <asp:Label ID="Label1" runat="server" CssClass="auto-style1"></asp:Label>
&nbsp;&nbsp;&nbsp; Código postal:
            <asp:Label ID="Label2" runat="server" CssClass="auto-style1"></asp:Label>
            <br />
            <br />
            Semanas:
            <asp:Label ID="Label3" runat="server" CssClass="auto-style1"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Monto:&nbsp;
            <asp:Label ID="Label4" runat="server" CssClass="auto-style1"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Días de descanso:
            <asp:Label ID="Label5" runat="server" CssClass="auto-style1"></asp:Label>
            <br />
            <br />
            Edad de la persona a ayudar: <asp:Label ID="Label6" runat="server" CssClass="auto-style1"></asp:Label>
            <br />
            <br />
            Hora de entrada: <asp:Label ID="Label7" runat="server" CssClass="auto-style1"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Hora de salida:
            <asp:Label ID="Label8" runat="server" CssClass="auto-style1"></asp:Label>
            <br />
            <br />
            Feha de inicio: <asp:Label ID="Label9" runat="server" CssClass="auto-style1"></asp:Label>
            <br />
            <br />
            Descripción:<br />
            <asp:Label ID="Label10" runat="server" CssClass="auto-style1"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Me interesa" OnClick="Button2_Click" />
            <br />
            <br />
            <asp:Label ID="Label11" runat="server"></asp:Label>
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
