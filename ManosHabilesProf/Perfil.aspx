<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="ManosHabilesProf.Perfil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Consulte y modifique su perfil</h2>
            <p>&nbsp;
                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Cerrar sesión" />
&nbsp;
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Volver al menú" />
            </p>
            <p>Nombre: <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
            <p>Apellido:
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </p>
            <p>Correo:
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </p>
            <p>Contraseña:
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            </p>
            <p>Código postal:
                <asp:TextBox ID="TextBox6" runat="server" Width="162px"></asp:TextBox>
            </p>
            <p>Descripción: </p>
            <p>
                <asp:TextBox ID="TextBox5" runat="server" Height="76px" Width="352px"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </p>
            <p>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Modificar" />
            </p>
            <p>&nbsp;</p>
        </div>
    </form>
</body>
</html>
