<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormAuto.aspx.cs" Inherits="WebTransportes.WebFormAuto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblMarca" runat="server" Text="Marca"></asp:Label>
            <asp:DropDownList ID="ddlMarca" runat="server" AutoPostBack="True"></asp:DropDownList>
            <br />
            <asp:Label ID="lblModelo" runat="server" Text="Modelo">
            </asp:Label><asp:TextBox ID="txtModelo" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblMatricula" runat="server" Text="Matricula"></asp:Label>
            <asp:TextBox ID="txtMatricula" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblPrecio" runat="server" Text="Precio"></asp:Label>
            <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblId" runat="server" Text="Id"></asp:Label>
            <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblBuscarPorMarca" runat="server" Text="Buscar autos por marca"></asp:Label>
            <asp:DropDownList ID="ddlTarerPorMarca" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTarerPorMarca_SelectedIndexChanged"></asp:DropDownList>
            <br />
            <asp:Button ID="btnGuardad" runat="server" Text="Guardar" OnClick="btnGuardad_Click" />
            <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
            <br />
            <asp:GridView ID="gridAuto" runat="server"></asp:GridView>


        </div>
    </form>
    
</body>
</html>
