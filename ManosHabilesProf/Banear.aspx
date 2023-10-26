<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Banear.aspx.cs" Inherits="ManosHabilesProf.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Banear</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Baneos/Reportes Disciplinarios<br />
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Cerrar sesión" />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
            &nbsp;&nbsp; Filtar Por:&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
&nbsp; &nbsp;Y&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList2" runat="server">
            </asp:DropDownList>
&nbsp; &nbsp;Y&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList3" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <br />
&nbsp;Entre:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;Y
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            Generar Lista Para Banear:&nbsp;
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Button" />
            <br />
            <br />
        </div>
        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataKeyNames="cCliente" OnRowCommand="GridView1_RowCommand" Width="233px">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Ban" HeaderText="Ban" Text="Banear" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Regresar al Menu Administrador" />
    </form>
</body>
</html>
