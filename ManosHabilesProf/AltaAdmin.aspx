<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaAdmin.aspx.cs" Inherits="ManosHabilesProf.AltaAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Alta admin</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Alta nuevo admin</h2>
            <br />
            Nombre:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            Apellido:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            Correo:<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            Contraseña:<asp:TextBox ID="TextBox4" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Crear cuenta" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Regresar al menú Admin" />
            <br />
        </div>
    </form>
</body>
</html>
