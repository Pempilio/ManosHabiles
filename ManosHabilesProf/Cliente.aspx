<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="ManosHabilesProf.Cliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <div>

             <h1>Profesionistas</h1>
             <p>
                 <asp:Button ID="Button3" runat="server" Text="Mis anuncios" />
                 <asp:Button ID="Button4" runat="server" Text="Cerrar sesión" />
             </p>

             <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
             </asp:DropDownList>
             <asp:DropDownList ID="DropDownList2" runat="server">
                 <asp:ListItem Value="0">Sexo (sin preferencia)</asp:ListItem>
                 <asp:ListItem Value="1">Masculino</asp:ListItem>
                 <asp:ListItem Value="2">Femenino</asp:ListItem>
             </asp:DropDownList>
             <asp:DropDownList ID="DropDownList3" runat="server">
             </asp:DropDownList>
             <asp:Button ID="Button2" runat="server" Height="26px" OnClick="Button2_Click" Text="Buscar" />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
             <asp:Button ID="Button1" runat="server" Text="Nuevo anuncio" OnClick="btn1"/>
             <br />
             <asp:GridView ID="GridView1" runat="server" Height="294px" Width="747px">
             </asp:GridView>
             <br />

         </div>
    </form>
</body>
</html>
