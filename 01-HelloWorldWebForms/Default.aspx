<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Hello World</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>HELLO WORLD</h1>
        <asp:Label Text="Escriba su nombre: " runat="server"/>
        <asp:TextBox ID="texto" runat="server" />
        <asp:Button Text="Enviar" runat="server" OnClick="ClickNombre" />
        <asp:Label ID="LabelError" Text="" ForeColor="Red" runat="server"/>
        <br/>
        <br/>
        <br/>
        <asp:Label ID="testo" Text=" " runat="server"/>
        
        <br/><asp:Button ID="Bien" Text="Bien" runat="server" OnClick="Bien_Click" />
            <asp:Button ID="Mal" Text="Mal" runat="server" OnClick="Mal_Click" />
        <br/><br/>
        <br/><asp:Label ID="Label1" Text="" runat="server"/>
        <br/><br/>
        
        <input type="email" placeholder="email" id="email"/><input type="submit"/>
    </div>
    </form>
</body>
</html>
