<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="UsuarioInactivo.aspx.cs" Inherits="Vistas.UsuarioInactivo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/funciones.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <h2 class="text-center white-text">Usuario inhabilitado. ¿Desea volver a habilitarlo?</h2>
    <div class="d-flex justify-content-center">
        <asp:Button runat="server" ID="btnConfirmIn" Text="Aceptar" CssClass="btn purple-gradient" OnClick="btnConfirmIn_Click" />
        <asp:Button runat="server" ID="btnRej" Text="Cancelar" CssClass="btn purple-gradient" OnClick="btnRej_Click" />
    </div>
</asp:Content>
