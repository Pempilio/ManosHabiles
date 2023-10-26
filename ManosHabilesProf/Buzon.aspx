<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Buzon.aspx.cs" Inherits="ManosHabilesProf.Buzon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Buzon</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Buzón de notificaciones</h2>
            <p>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Regresar al menú" />
            </p>
            <p>
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </p>
            <p>
                <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                </asp:GridView>
            </p>
        </div>
    </form>
</body>
</html>
