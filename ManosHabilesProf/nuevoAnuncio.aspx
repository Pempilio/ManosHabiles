<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="nuevoAnuncio.aspx.cs" Inherits="ManosHabilesProf.nuevoAnuncio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <div>
            ¡Crea un nuevo anuncio!

            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Cerrar sesión" />

            <br />
            <hr />
&nbsp;Categoria&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Semanas&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Monto&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dias de descanso&nbsp;&nbsp; Estancia&nbsp;&nbsp;&nbsp;
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <asp:TextBox ID="TextBox2" runat="server" Width="108px"></asp:TextBox>
            <asp:TextBox ID="TextBox3" runat="server" Width="108px"></asp:TextBox>
            <asp:TextBox ID="TextBox4" runat="server" Width="108px"></asp:TextBox>
&nbsp;<asp:DropDownList ID="DropDownList2" runat="server">
                <asp:ListItem Value="1">verdadero</asp:ListItem>
                <asp:ListItem Value="0">falso</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            Hora de entrada&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Hora de salida&nbsp;&nbsp;&nbsp;&nbsp; Fecha de inicio&nbsp;&nbsp;&nbsp; Edad<br />
            <asp:TextBox ID="TextBox6" runat="server" Width="108px"></asp:TextBox>
            <asp:TextBox ID="TextBox7" runat="server" Width="108px"></asp:TextBox>
            <asp:TextBox ID="TextBox8" runat="server" Width="108px"></asp:TextBox>
            <asp:TextBox ID="TextBox10" runat="server" Width="69px"></asp:TextBox>
            <br />
            Descripción
            <br />
            <asp:TextBox ID="TextBox9" runat="server" Height="57px" Width="589px"></asp:TextBox>
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button2" runat="server" Height="28px" Text="Regresar" Width="107px" OnClick="Button2_Click" />
            &nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Height="28px" Text="Publicar" Width="107px" OnClick="Button1_Click" />
            <br />
            <br />

        </div>
    </form>
</body>
</html>
