<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="crearCuenta.aspx.cs" Inherits="ManosHabilesProf.crearCuenta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Crear una cuenta</title>
    </head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>¡Crea tu cuenta!</h2>

            <br />
            Nombre:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Apellido:
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            Fecha de nacimiento:
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
&nbsp;(mm/dd/aaaa)<br />
            <br />
            Sexo:<br />
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            </asp:RadioButtonList>
            <br />
            <br />
            Correo:
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            Contraseña:
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <br />
            Código postal:
            <asp:TextBox ID="TextBox5" runat="server" Width="162px"></asp:TextBox>
            <br />
            <br />
            Descripción:<br />
            Dile a los clientes algo que pueda hacer que se sientan atraidos para contratarte.<br />
            <asp:TextBox ID="TextBox8" runat="server" Height="99px" Width="984px"></asp:TextBox>
            <br />
            <br />
            Años de experiencia:
            <asp:TextBox ID="TextBox6" runat="server" Width="131px"></asp:TextBox>
            <br />
            <br />
            Especialidad:&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Darme de alta" OnClick="Button1_Click" />

            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Inicio de sesion" />

        </div>
    </form>
</body>
</html>
